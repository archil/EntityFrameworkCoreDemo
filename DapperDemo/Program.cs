using System;
using System.Data.SqlClient;

namespace DapperDemo
{
    class Program
    {
        public class Product
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public int CategoryId { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
        }

        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection())
            {

            }
        }
    }
}
