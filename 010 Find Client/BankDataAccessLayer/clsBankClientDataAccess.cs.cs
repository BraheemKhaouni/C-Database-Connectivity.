using System;
using System.Data;
using System.Data.SqlClient;

namespace BankDataAccessLayer
{
    public class clsBankClientDataAccess
    {
        public static bool GetClientByID( ref int  clientID,ref string firstName,ref string lastName,ref string email,
          ref  string phone,ref string accountNumber,ref int pinCode,ref int accountBalance)
        {
            SqlConnection connection = new SqlConnection(clsClientDataSettings.connectionstring);
            string QUERY = "select * from Clients WHERE ClientID =@ClientID";

            SqlCommand command =new SqlCommand(QUERY, connection);
            command.Parameters.AddWithValue("@ClientID",clientID);
            bool IsFound=false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
               while (reader.Read())
                {
                    IsFound = true;
                     clientID = (int)reader["ClientID"];
                    firstName = (string)reader["FirstName"];
                    lastName = (string)reader["LastName"];
                    email = (string)reader["Email"];
                     phone = (string)reader["Phone"];
                     accountNumber = (string)reader["AccountNumber"];
                     pinCode = (int)reader["PinCode"];
                     accountBalance = (int)reader["AccountBalance"];
                }
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
    }
}
