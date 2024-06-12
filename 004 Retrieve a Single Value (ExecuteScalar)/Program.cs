using System;
using System.Net;
using System.Data;
using System.Data.SqlClient;

public class Program
{
    static string stringconnction = "Server=.;database=StudentsDB;user= sa;password=kaka2020";
    public static string GetFirstName(int id)
    {
        string Fname = "";
        SqlConnection connection = new SqlConnection(stringconnction);
        string query = "SELECT FIRSTNAME FROM Students WHERE ID = @ID";


        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);

        try
        {
            connection.Open();
            Object o = command.ExecuteScalar();
            if (o != null )
            {
                Fname = o.ToString();
            }
           else
            {
                Fname = "";
            }


            
          
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return Fname;

    }




    public static void Main()
    {

       Console.WriteLine(GetFirstName(1));
        Console.ReadKey();
    }
}