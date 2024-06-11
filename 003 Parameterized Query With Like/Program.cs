using System;
using System.Net;
using System.Data;
using System.Data.SqlClient;

public class Program
{
    static string stringconnction = "Server=.;database=StudentsDB;user= sa;password=kaka2020";
   public static void PrintStudentsWithStart(string StartWith)
    {
        SqlConnection connection = new SqlConnection(stringconnction);
        string query = $"select * from Students where FirstName LIKE '{@StartWith}%' ";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@StartWith", StartWith);

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

    public static void PrintStudentsWithEnd(string EndWith)
    {
        SqlConnection connection = new SqlConnection(stringconnction);
        string query = $"select * from Students where FirstName LIKE '%{@EndWith}' ";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@EndWith", EndWith);

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

    public static void PrintStudentsContains(string Contains)
    {
        SqlConnection connection = new SqlConnection(stringconnction);
        string query = $"select * from Students where FirstName LIKE '%{@Contains}%' ";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Contains", Contains);

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

        PrintStudentsWithStart("A");
        PrintStudentsWithEnd("A");
        PrintStudentsContains("z");
        Console.ReadKey();
    }
}