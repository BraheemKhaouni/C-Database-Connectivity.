using System;
using System.Data;
using BankDataAccessLayer;

namespace BankBuissniseLayer
{
    public class clsClient
    {
        public enum enMode { AddNew, Update };
        public enMode Mode;
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AccountNumber { get; set; }
        public int PinCode { get; set; }
        public int AccountBalance { get; set; }

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
            Mode = enMode.AddNew;
        }
        private clsClient(int ClientID, string FirstName, string LastName, string Email, string
            Phone, string AccountNumber, int PinCode, int AccountBalance)

        {
            this.ClientID = ClientID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.AccountNumber = AccountNumber;
            this.PinCode = PinCode;
            this.AccountBalance = AccountBalance;
        }
        private bool _AddNewClient()
        {
            this.ClientID = clsClientDataAccess.AddNewClient(this.FirstName, this.LastName, this.Email, this.Phone
                                                , this.AccountNumber, this.PinCode, this.AccountBalance);

            return (ClientID != -1);
        }
        private bool _UpdateClient()
        {
            return true;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewClient())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    { return false; }
                case enMode.Update:
                    return _UpdateClient();



            }
            return false;

        }
    }







    
}
