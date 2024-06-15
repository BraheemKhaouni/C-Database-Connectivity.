using System;
using System.Data;
using System.Security.Policy;
using BankDataAccessLayer;

namespace BankBusinessLayer
{
    public class clsBankClient
    {
        public int ClientID {  get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AccountNumber { get; set; }
        public int PinCode { get; set; }
        public int AccountBalance { get; set; }

        public clsBankClient() 
        {
            this.ClientID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.AccountNumber="";
            this.PinCode = -1;
            this.AccountBalance = -1;
        }
        public clsBankClient(int clientID, string firstName, string lastName, string email, string phone, string accountNumber, int pinCode, int accountBalance)
        {
            ClientID = clientID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            AccountNumber = accountNumber;
            PinCode = pinCode;
            AccountBalance = accountBalance;
        }


        public static clsBankClient Find(int ID)
        {
           int ClientID = -1;
           string FirstName = "";
           string LastName = "";
           string Email = "";
           string Phone = "";
           string AccountNumber = "";
           int PinCode = -1;
           int AccountBalance = -1;
            if(clsBankClientDataAccess.GetClientByID( ref ID,ref FirstName,ref  LastName,
               ref  Email,ref  Phone,ref  AccountNumber,ref  PinCode,ref  AccountBalance))
            {
                return new clsBankClient(ClientID, FirstName, LastName, Email, Phone,
                                         AccountNumber, PinCode, AccountBalance);
            }
            else
            {
                return null;
            }
        }
    }
}
