using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection_Database;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=DESKTOP-AQ2V6AN\SQLEXPRESS;Database=TestDatabase;Trusted_Connection=True;";
            var sql = new Database().MSSQL(connectionString);
            Console.WriteLine("DatabaseExists: " + sql.DatabaseExists().ToString());

            // One data

            var tableA = sql.ExecuteSelectOneStatement<TableA>("Select * From TableA");
            Console.WriteLine("One data");
            if (tableA != null)
            {
                Console.WriteLine($"Name: {tableA.Name} - Age: {tableA.Age}");
            }


            // list data
            var listdata = sql.ExecuteSelectManyStatement<TableA>("Select * From TableA");
            Console.WriteLine("List data");
            foreach (var item in listdata)
            {
                Console.WriteLine($"Name: {item.Name} - Age: {item.Age}");
            }
            Console.ReadKey();
        }
    }
    class TableA
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
