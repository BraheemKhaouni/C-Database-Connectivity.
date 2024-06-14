using System;
using System.Net;
using System.Data;
using System.Data.SqlClient;

public class Program
{
    static string connectionstring = "Server=.;database=StudentsDB;user =sa;password=kaka2020";


    public static void UpdateStudents(int Student_ID,string NewFName)
    {
        SqlConnection connection = new SqlConnection(connectionstring);

        string qurey = "Update Students set FirstName = @FirstName where ID = @ID";

        SqlCommand command = new SqlCommand(qurey, connection);
        command.Parameters.AddWithValue("@FirstName", NewFName);

        command.Parameters.AddWithValue("@ID", Student_ID);



        try
        {
            connection.Open();
            int AddRow = command.ExecuteNonQuery();
            if (AddRow > 0)
            {
                Console.WriteLine("Is Done");
            }
            else
            {
                Console.WriteLine("No");
            }

            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public static void Main()
    {

        UpdateStudents(6, "KOKO");

        Console.ReadKey();
    }
}