using System;
using System.Net;
using System.Data;
using System.Data.SqlClient;

public class Program
{
    static string stringconnction = "Server=.;database=StudentsDB;user= sa;password=kaka2020";

    static bool FindStudentByID(int StudentID, ref stStudent student)
    {
        bool IsFound=false;
        SqlConnection connection = new SqlConnection(stringconnction);
        string QUERY = "select * from Students where ID = @ID";
        SqlCommand command = new SqlCommand(QUERY, connection);
        command.Parameters.AddWithValue("@ID", StudentID);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                IsFound = true;
                student.id = (int)reader["ID"];
                student.FirstName = (string)reader["FirstName"];
                student.LastName = (string)reader["LastName"];
                student.Email = (string)reader["Email"];
                student.Phone= (string)reader["Phone"];
                student.universitymajor = (string)reader["UniversityMajor"];


            }
            else
            {
                IsFound = false;
            }


            connection.Close();
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return IsFound;
    }





    public struct stStudent
    {
       
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string universitymajor { get; set; }
      
    }
    public static void Main()
    {
        stStudent student = new stStudent();

        if(FindStudentByID(1,ref student))
        {
            Console.WriteLine(" Student Info");
            Console.WriteLine($" id             : {student.id}");
            Console.WriteLine($" FirstName      : {student.FirstName}");
            Console.WriteLine($" LastName       : {student.LastName}");
            Console.WriteLine($" Email          : {student.Email}");
            Console.WriteLine($" Phone          : {student.Phone}");
            Console.WriteLine($" UniversityMajor: {student.universitymajor}");
           

        }
        else
        {
            Console.WriteLine("No, ");
        }

        Console.ReadKey();
    }
}