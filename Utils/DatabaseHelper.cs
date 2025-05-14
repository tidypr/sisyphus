using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sisyphus
{
    public static class DatabaseHelper
    {
        public static string ConnectionString = "Server=localhost;Port=3306;Database=SisyphusDB;User=root;Password=rootpassword;";

        // 기본 ExecuteScalar
        public static int ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // 기본 ExecuteNonQuery
        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // 기본 ExecuteQuery
        public static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // MySQL 관련 오류 처리
                MessageBox.Show($"MySQL 오류: {ex.Message}", "데이터베이스 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                // 일반적인 오류 처리
                MessageBox.Show($"예기치 않은 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        // ✅ 트랜잭션용 커넥션 반환
        public static MySqlConnection GetOpenConnection()
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        // ✅ 트랜잭션에서 ExecuteNonQuery 실행
        public static int ExecuteNonQuery(string query, MySqlConnection conn, MySqlTransaction transaction, params MySqlParameter[] parameters)
        {
            using (var cmd = new MySqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        // ✅ 트랜잭션 실행을 위한 래퍼 (선택)
        public static bool ExecuteInTransaction(Func<MySqlConnection, MySqlTransaction, bool> action)
        {
            using (var conn = GetOpenConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    bool result = action(conn, transaction);
                    transaction.Commit();
                    return result;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
