using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;

using System.Text;
using System.Threading.Tasks;

namespace sisyphus
{
    public class MenuItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; } = 1;

        //public double SeatNumber { get; set; }
    }

    public class Table
    {
        public string Name { get; set; }
        public List<MenuItem> Items { get; set; } = new List<MenuItem>();

        public int GetTotalPrice()
        {
            return Items.Sum(item => item.Price);
        }
    }

    public static class DummyData
    {
        public static List<Table> GetTables()
        {
            return new List<Table>
        {
            new Table
            {
                Name = "Table 1",
                Items = new List<MenuItem>
                {
                    new MenuItem { Name = "소주", Price = 4000 , Quantity = 4},
                    new MenuItem { Name = "맥주", Price = 4000 , Quantity= 2},
                    new MenuItem { Name = "음료수", Price = 2000, Quantity=20 }
                }
            },
            new Table
            {
                Name = "Table 2",
                Items = new List<MenuItem>
                {
                    new MenuItem { Name = "소주", Price = 4000 , Quantity = 8},
                    new MenuItem { Name = "맥주", Price = 4000 , Quantity= 4},
                    new MenuItem { Name = "음료수", Price = 2000, Quantity=1 }
                }
            },
             new Table
            {
                Name = "Table 3",
                Items = new List<MenuItem>
                {
                  new MenuItem { Name = "소주", Price = 4000 , Quantity = 2},
                    new MenuItem { Name = "맥주", Price = 4000 , Quantity= 44},
                    new MenuItem { Name = "음료수", Price = 2000, Quantity=5 }
                }
            },
        };
        }
    }



}
