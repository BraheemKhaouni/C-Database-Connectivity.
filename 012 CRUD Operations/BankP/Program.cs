using System;
using System.Data;
using System.Globalization;
using BankMiddleTier;

namespace BankP
{
    internal class Program
    {
         static void TastFindClient(int ID)
        {
            clsClient client = clsClient.Find(ID);
            if (client != null)
            {
                Console.WriteLine(" Client Info \n");
                Console.WriteLine(" Client ID      : "+ ID);
                Console.WriteLine(" Full Name      : "+client.FirstName + " " + client.LastName);
                Console.WriteLine(" Email          : "+client.Email);
                Console.WriteLine(" Phone          : "+client.Phone);
                Console.WriteLine(" AccountNumber  : "+client.AccountNumber);
                Console.WriteLine(" PinCode        : "+client.PinCode);
                Console.WriteLine(" AccountBalance : "+client.AccountBalance);
            }
            else
            {
                Console.WriteLine("No");
            }
        }
         static void TestAddNew()
        {
          clsClient client = new clsClient();
            client.FirstName = "Test";
            client.LastName = "Test";
            client.Email = "Test";
            client.Phone = "Test";
            client.AccountNumber = "Test";
            client.PinCode = 9999;
            client.AccountBalance= 9000;

            if(client.Save())
            {
                Console.WriteLine("yes");
            }

        }

         static void TestUpdate(int ID)
        {
            clsClient client = clsClient.Find(ID);

            if(client != null)
            {
                client.FirstName = "Ahmed";
                client.LastName = "Ali";
                client.Email = "@Ali";
                client.Phone = "056565656";
                client.AccountNumber = "A112";
                client.PinCode = 1212;
                client.AccountBalance = 5300;
            }
            if(client.Save() )
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

         static void TestDelete(int ID)

        {


            if (clsClient.DeleteClient(ID))
            {
                Console.WriteLine("koko");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

         static  void TestIsEclientExit(int id)
        {

            if (clsClient.IsClientxExit(id))
            {
                Console.WriteLine("koko");
            }
            else
            {
                Console.WriteLine("no");
            }

        }


         static void  TestShowllClients()
        {
            DataTable  T1 = new DataTable();
            T1=clsClient.GetAllClients();

            foreach (DataRow row in T1.Rows)
            {
                Console.WriteLine($"{row["ClientID"]},  {row["FirstName"]} {row["LastName"]}");
            }
            
        }
        

        


        static void Main(string[] args)
        {
            //TastFindClient(1);
            //TestAddNew();
            //TestUpdate(9);
            //TestDelete(9);
            //TestIsEclientExit(1);
            //TestIsEclientExit(19);



            TestShowllClients();






            Console.ReadKey();
        }
    }
}
