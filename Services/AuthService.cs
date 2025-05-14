using MySql.Data.MySqlClient;

namespace sisyphus.Services
{
    public static class AuthService
    {
        public static bool Login(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
            int count = DatabaseHelper.ExecuteScalar(query,
                new MySqlParameter("@Username", username),
                new MySqlParameter("@Password", password));
            return count > 0;
        }

        public static bool Register(string username, string password)
        {
            string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
            int result = DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@Username", username),
                new MySqlParameter("@Password", password));
            return result > 0;
        }
    }
}
