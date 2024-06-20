using System;
using System.Data;
using System.Linq;
using System.Net.Cache;


namespace _013_DataTable
{
    internal class Program
    {
        static void Main(string[] args)
        {


            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name",typeof(string));
            dt.Columns.Add("Country",typeof(string));
            dt.Columns.Add("Age",typeof (string));
            dt.Columns.Add("Salary",typeof (double));



            dt.Rows.Add(1, "Brahim", "Alg", "26", 1000);
            dt.Rows.Add(2, "Ali", "USA", "27", 7000);
            dt.Rows.Add(3, "Moh", "Alg", "25", 1500);
            dt.Rows.Add(4, "Adel", "FFF", "22", 4000);
            dt.Rows.Add(5, "Hamaza", "EGB", "30", 5000);


            Console.WriteLine("\t _________________________________________________________________________________________");
            Console.WriteLine("\t|{0,-4}|{1,-30}|{2,-20}|{3,-10}|{4,-21}|", "ID", "Name", "Country","Age", "Salary");




            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("\t|-----------------------------------------------------------------------------------------|");
                Console.WriteLine("\t|{0,-4}|{1,-30}|{2,-20}|{3,-10}|{4,-21}|",
                                      row["ID"], row["Name"], row["Country"], row["Age"], row["Salary"]);
            }
            Console.WriteLine("\t|_________________________________________________________________________________________|");

           

            Console.ReadKey();
















        }
    }
}
