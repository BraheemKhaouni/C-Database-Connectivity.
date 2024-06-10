using System;
using System.Net;
using System.Data;
using System.Data.SqlClient;

public class Programm
{

    static string connectionstring = "Server=.;Database=StudentsDB;user = sa;password=kaka2020";
    static public void ShowAllStudents()
    {
        SqlConnection connection = new SqlConnection(connectionstring);

        string QUERY = "SELECT * FROM STUDENTS";
        SqlCommand command = new SqlCommand(QUERY, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ID = Convert.ToInt32(reader["ID"]);
                string FirstName = Convert.ToString(reader["FirstName"]);
                string LastName = Convert.ToString(reader["LastName"]);
                string Email = Convert.ToString(reader["Email"]);
                string Phone = Convert.ToString(reader["Phone"]);
                string UniversityMajor = Convert.ToString(reader["UniversityMajor"]);

                Console.WriteLine(" -----------------------------");

                Console.WriteLine($" Student_ID      : {ID}");
                Console.WriteLine($" SFullName       : {FirstName} {LastName}");
                Console.WriteLine($" Email           : {Email}");
                Console.WriteLine($" Phone           : {Phone}");
                Console.WriteLine($" UniversityMajor : {UniversityMajor}");



            }
            Console.WriteLine(" -----------------------------");

            reader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    static void Main(string[] args)
    {
        ShowAllStudents();
        Console.ReadKey();
    }
}
