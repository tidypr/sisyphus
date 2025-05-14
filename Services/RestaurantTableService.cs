using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using sisyphus.Models;

namespace sisyphus.Services
{
    public static class RestaurantTableService
    {
        public static List<RestaurantTable> GetAllTables()
        {
            string query = "SELECT * FROM RestaurantTable";
            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            List<RestaurantTable> tables = new List<RestaurantTable>();

            foreach (DataRow row in dataTable.Rows)
            {
                var table = new RestaurantTable
                {
                    TableID = Convert.ToInt32(row["TableID"]),
                    TableName = row["TableName"].ToString(),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    Status = row["Status"].ToString()
                };
                tables.Add(table);
            }

            return tables;
        }

        public static List<Item> GetItemsByTableId(int tableId)
        {
            string query = @"
        SELECT 
            i.ItemID, 
            i.Name, 
            od.Quantity, 
            od.Price, 
            i.ImageUrl
        FROM 
            OrderDetail od
        JOIN 
            Item i ON od.ItemID = i.ItemID
        WHERE 
            od.TableID = @TableID

        ORDER BY 
            od.OrderTime";

            // 쿼리 실행
            DataTable dataTable = DatabaseHelper.ExecuteQuery(query,
                new MySql.Data.MySqlClient.MySqlParameter("@TableID", tableId));

            List<Item> items = new List<Item>();

            foreach (DataRow row in dataTable.Rows)
            {
                var item = new Item
                {
                    ItemID = Convert.ToInt32(row["ItemID"]),
                    Name = row["Name"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Price = Convert.ToDecimal(row["Price"]),
                    ImageUrl = row["ImageUrl"].ToString()
                };
                items.Add(item);
            }

            return items;
        }

        public static bool AddItemToTable(int tableId, int itemId, int quantity, decimal price)
        {
            return DatabaseHelper.ExecuteInTransaction((conn, transaction) =>
            {
                string insertQuery = @"
            INSERT INTO OrderDetail (TableID, ItemID, Quantity, Price)
            VALUES (@TableID, @ItemID, @Quantity, @Price);";

                string updateQuery = @"
            UPDATE RestaurantTable
            SET TotalAmount = TotalAmount + (@Price * @Quantity),
                Status = 'Occupied'
            WHERE TableID = @TableID;";

                DatabaseHelper.ExecuteNonQuery(insertQuery, conn, transaction,
                    new MySqlParameter("@TableID", tableId),
                    new MySqlParameter("@ItemID", itemId),
                    new MySqlParameter("@Quantity", quantity),
                    new MySqlParameter("@Price", price));

                DatabaseHelper.ExecuteNonQuery(updateQuery, conn, transaction,
                    new MySqlParameter("@TableID", tableId),
                    new MySqlParameter("@Quantity", quantity),
                    new MySqlParameter("@Price", price));

                return true;
            });
        }

        public static bool DeleteTableData(int tableId)
        {
            string deleteOrderDetailQuery = @"
            DELETE FROM OrderDetail
            WHERE TableID = @TableID;";

            string updateTableStatusQuery = @"
            UPDATE RestaurantTable
            SET Status = 'Available', TotalAmount = 0
            WHERE TableID = @TableID;";

            // 트랜잭션을 사용하여 두 가지 작업을 모두 처리
            return DatabaseHelper.ExecuteInTransaction((conn, transaction) =>
            {
                // 주문 내역 삭제
                DatabaseHelper.ExecuteNonQuery(deleteOrderDetailQuery, conn, transaction,
                    new MySqlParameter("@TableID", tableId));

                // 테이블 상태 업데이트
                DatabaseHelper.ExecuteNonQuery(updateTableStatusQuery, conn, transaction,
                    new MySqlParameter("@TableID", tableId));

                return true;
            });
        }


    }
}
