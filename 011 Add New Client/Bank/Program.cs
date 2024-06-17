using System;
using System.ComponentModel;
using System.Data;
using BankBuissniseLayer;




namespace Bank
{




    internal class Program
    {
        public static void AddNewTest()
        {
            clsClient client = new clsClient();
            client.FirstName = "Ali";
            client.LastName = "Ali";
            client.Email = "@Ali";
            client.Phone = "00000";
            client.AccountNumber = "A103";
            client.PinCode = 2222;
            client.AccountBalance = 1000;
            if (client.Save())
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        static void Main(string[] args)
        {

            AddNewTest();
            Console.ReadKey();

        }
    }
}
