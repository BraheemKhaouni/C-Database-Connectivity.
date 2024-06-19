using System;
using System.Data;
using BankDataTier;

namespace BankMiddleTier
{
    public class clsClient
    {
        public enum enMode {Add,Update };
        public enMode Mode;
        public int ClientID {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public string Phone { get; set; }
        public string AccountNumber { get; set; }
        public int PinCode { get; set; }
        public int AccountBalance { get; set; }
        private clsClient(int ClientID,string FirstName,string LastName,string Email,
            string Phone,string AccountNumber,int PinCode,int AccountBalance)
        {
            this.ClientID = ClientID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.AccountNumber = AccountNumber;
            this.PinCode = PinCode;
            this.AccountBalance = AccountBalance;

            Mode = enMode.Update;
        }
        public clsClient()
        {
            this.ClientID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.AccountNumber = "";
            this.PinCode = 0;
            this.AccountBalance = 0;

            Mode= enMode.Add;
        }

      private bool _AddNewClient()
        {
            this.ClientID = clsClientDataAccess.AddNewClient(this.FirstName, this.LastName, 
                                                             this.Email, this.Phone, this.AccountNumber,
                                                             this.PinCode, this.AccountBalance);


            return (ClientID != -1);
        }

        private bool _UpdateClient()
        {
            return clsClientDataAccess.UpdateClient(this.ClientID,this.FirstName, this.LastName,
                                                    this.Email, this.Phone, this.AccountNumber,
                                                    this.PinCode, this.AccountBalance);
        }
        public static clsClient Find(int ID)
        {
            
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Phone = "";
            string AccountNumber = "";
            int PinCode = 0;
            int AccountBalance = 0;

            if(clsClientDataAccess.GetClientByID(ID,ref FirstName,ref LastName,ref Email,ref Phone,
               ref AccountNumber,ref PinCode,ref AccountBalance))
            {
                return new clsClient(ID, FirstName, LastName, Email, Phone, AccountNumber,
                    PinCode, AccountBalance);    
            }
            else
            {
                return null ;
            }
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.Add:
                    if(_AddNewClient())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateClient(); 

          
            }

            return false;
        }

        public static bool DeleteClient(int ID)
        {
            return clsClientDataAccess.DeleteClient(ID);
        }

        public static bool IsClientxExit(int ID)
        {
            return clsClientDataAccess.IsContactExist(ID);
        }

        public static DataTable GetAllClients()
        {
            return clsClientDataAccess.GetAllClients();
        }



    }
}
