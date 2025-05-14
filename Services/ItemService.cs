using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using sisyphus.Models;

namespace sisyphus.Services
{
    public static class ItemService
    {
        public static List<Item> GetAllItems()
        {
            string query = "SELECT * FROM Item";
            List<Item> items = new List<Item>();

            try
            {
                DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

                foreach (DataRow row in dataTable.Rows)
                {
                    var item = new Item
                    {
                        ItemID = Convert.ToInt32(row["ItemID"]),
                        Name = row["Name"].ToString(),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        Price = Convert.ToDecimal(row["Price"]),
                        ImageUrl = row["ImageUrl"].ToString(),
                    };
                    items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DB 오류: " + ex.Message);
            }

            return items;
        }
    }
}
