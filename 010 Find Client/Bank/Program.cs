using System;
using System.Data;
using System.Diagnostics.Contracts;
using BankBusinessLayer;

namespace Bank
{

    internal class Program
    {
        public static void TestFindClient(int ID)
        {
            clsBankClient client = clsBankClient.Find(ID);
            if (client != null )
            {
                Console.WriteLine("koko         "+ID);
                Console.WriteLine("koko         "+client.FirstName + " " + client.LastName);
                Console.WriteLine("koko         "+client.Email);
                Console.WriteLine("koko         "+client.Phone);
                Console.WriteLine("koko         "+client.AccountNumber);
                Console.WriteLine("koko         "+client.PinCode);
                Console.WriteLine("koko         "+client.AccountBalance);

            }

            else
            {
                Console.WriteLine("No cLIENT");
            }
        }
        static void Main(string[] args)
        {
            TestFindClient(1);
            Console.ReadKey();
        }
    }
}
