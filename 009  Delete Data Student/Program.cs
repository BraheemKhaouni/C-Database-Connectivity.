using System;
using System.Net;
using System.Data;
using System.Data.SqlClient;

public class Program
{
    static string connectionstring = "Server=.;database=StudentsDB;user =sa;password=kaka2020";


    public static void DeleteStudent(int Student_ID)
    {
        SqlConnection connection = new SqlConnection(connectionstring);

        string qurey = "delete from Students  where ID = @ID";

        SqlCommand command = new SqlCommand(qurey, connection);

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

        DeleteStudent(64);

        Console.ReadKey();
    }
}