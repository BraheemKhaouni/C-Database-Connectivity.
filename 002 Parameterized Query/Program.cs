using System;
using System.Net;
using System.Data;
using System.Data.SqlClient;


class Program
{

    static string stringconnection = "Server=.;database=StudentsDB;user = sa;password=kaka2020";
    public static void PrintWithFirstName(string FirstName,string UniversityMajor)
    {
        SqlConnection connection =new SqlConnection(stringconnection);

        string query = "select* from Students where FirstName =@FirstName and UniversityMajor =@universitymajor";

        SqlCommand command =new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@FirstName", FirstName);
        command.Parameters.AddWithValue("@UniversityMajor", UniversityMajor);


        try

        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("-----------------------------------");
                int id = Convert.ToInt32(reader["ID"]);
                string firstname = Convert.ToString(reader["FirstName"]);
                string lastname = Convert.ToString(reader["LastName"]);
                string email = Convert.ToString(reader["Email"]);
                string phone = Convert.ToString(reader["Phone"]);
                string universitymajor = Convert.ToString(reader["UniversityMajor"]);



                Console.WriteLine($"id              : {id}");
                Console.WriteLine($"FirstName       : {firstname}");
                Console.WriteLine($"LastName        : {lastname}");
                Console.WriteLine($"Email           : {email}");
                Console.WriteLine($"Phone           : {phone}");
                Console.WriteLine($"UniversityMajor : {universitymajor}");

            }
            connection.Close();
            reader.Close();
        }
        catch (Exception ex)
        {
            
            Console.WriteLine(ex.Message);
        }
    }

    public static void Main()
    {
        PrintWithFirstName("Ahmed","BIB");
        Console.ReadKey();
    }
}