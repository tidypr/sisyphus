using System;
using System.Collections.Generic;
using System.Data;
using sisyphus.Models;

namespace sisyphus.Models
{
    public class RestaurantTable
    {
        public int TableID { get; set; }
        public string TableName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
