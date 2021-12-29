using SQLLiteProducts;
using System;
using System.Data.SQLite;

namespace SQLLiteProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadProducts();
        }
        private static void ReadProducts()
        {
            Database databaseObj = new Database();
            string query = "SELECT Product.ProductName AS Product, Product.Price AS Price, ProductCategory.categoryname AS Category FROM Product Join ProductCategory ON Product.categoryid = ProductCategory.rowid";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObj.myConnection);
            databaseObj.OpenConnection();

            SQLiteDataReader data = myCommand.ExecuteReader();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    Console.WriteLine($"Product: {data["Product"]}. Price: {data["Price"]}. Category: {data["Category"]}");
                }
            }

            databaseObj.CloseConnection();
        }
    }
}
