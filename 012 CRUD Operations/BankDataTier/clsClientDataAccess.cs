using System;
using System.Data;
using System.Data.SqlClient;


namespace BankDataTier
{
   public class clsClientDataAccess
    {

        public struct stClient
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string AccountNumber { get; set; }
            public int PinCode { get; set; }
            public int AccountBalance { get; set; }
        }



        public static bool GetClientByID(  int ID,ref  string firstName,ref string lastName,ref string email,
           ref string phone,ref string accountNumber,ref int pinCode,ref int accountBalance)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string QUERY = "SELECT * FROM Clients WHERE ClientID = @ClientID";
            SqlCommand command = new SqlCommand(QUERY, connection);
            command.Parameters.AddWithValue("@ClientID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

               if (reader.Read())
                {
                     IsFound = true;
                     ID = (int)reader["ClientID"];
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
                IsFound=false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

      public static int AddNewClient(string FirstName, string LastName, string Email,
         string Phone, string AccountNumber, int PinCode, int AccountBalance)
        {
            int Client_ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string QUERY = @"insert into Clients (FirstName,LastName,Email,Phone,AccountNumber,PinCode,AccountBalance)
                           values (@FirstName, @LastName, @Email, @Phone, @AccountNumber,@PinCode, @AccountBalance);
                           SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(@QUERY, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@AccountBalance", AccountBalance);

            try
            {
                connection.Open();

                object Rus = command.ExecuteScalar();

                if (Rus != null&&int.TryParse(Rus.ToString(),out int ID))
                {
                    Client_ID = ID;
                }
                
            }
            catch
            { 

            }
            finally
            {
                connection.Close();
            }
            return Client_ID;
        }





        public static bool UpdateClient(int ID, string FirstName, string LastName, string Email,
            string Phone, string AccountNumber, int PinCode, int AccountBalance)
        {
            int RowEffect = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string QUERY = "UPDATE [dbo].[Clients]\r\n" +
                " SET FirstName  = @FirstName" +
                ",LastName       = @LastName" +
                ",Email          = @Email " +
                ",Phone          = @Phone  " +
                ",AccountNumber  = @AccountNumber " +
                ",PinCode        = @PinCode  " +
                ",AccountBalance = @AccountBalance" +
                " WHERE ClientID = @ClientID";
            SqlCommand command = new SqlCommand(QUERY, connection);
            command.Parameters.AddWithValue("@FirstName",      FirstName  );
            command.Parameters.AddWithValue("@LastName",       LastName   );
            command.Parameters.AddWithValue("@Email ",         Email    );
            command.Parameters.AddWithValue("@Phone  ",        Phone      );
            command.Parameters.AddWithValue("@AccountNumber ", AccountNumber );
            command.Parameters.AddWithValue("@PinCode  ",      PinCode    );
            command.Parameters.AddWithValue("@AccountBalance", AccountBalance);
            command.Parameters.AddWithValue("@ClientID",       ID   );

            try
            {
                connection.Open();
                RowEffect = command.ExecuteNonQuery();

            }
            catch 
            {

            }
            finally
            {
                connection.Close();
            }




            return RowEffect > 0;

        }


        public static bool DeleteClient(int ID)
        {
            int RowEffect = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "delete from Clients " +
                           "where ClientID = @ClientID";
            SqlCommand command = new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@ClientID", ID);

            try
            {
                connection.Open();
                RowEffect = command.ExecuteNonQuery();

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return RowEffect  > 0;

        }
        public static bool IsContactExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Clients WHERE ClientID = @ClientID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static DataTable GetAllClients()
        {
            DataTable table = new DataTable();


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string QUERY = "select * from Clients";

            SqlCommand command = new SqlCommand(@QUERY, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if(reader.HasRows)
                {
                    table.Load(reader); 


                }

                reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }


            return table;   
        }












    }
}
