using System;
using System.Data;
using System.Data.SqlClient;

namespace BankDataAccessLayer
{
    public class clsClientDataAccess
    {
      public static int AddNewClient(string firstName, string lastName, string email, string phone,
          string accountNumber, int pinCode, int accountBalance)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"insert into Clients 
                           values(@FirstName,@LastName,@Email,@Phone,@AccountNumber,@PinCode,@AccountBalance);
                           SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName     ",firstName);
            command.Parameters.AddWithValue("@LastName      ", lastName);
            command.Parameters.AddWithValue("@Email         ", email);
            command.Parameters.AddWithValue("@Phone         ", phone);
            command.Parameters.AddWithValue("@AccountNumber ", accountNumber);
            command.Parameters.AddWithValue("@PinCode       ", pinCode);
            command.Parameters.AddWithValue("@AccountBalance", accountBalance);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID)) 
                {
                    ID = insertedID;
                        
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }
    }
}
