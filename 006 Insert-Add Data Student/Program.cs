using System;
using System.Net;
using System.Data;
using System.Data.SqlClient;

public class Program
{
    static string connectionstring = "Server=.;database=StudentsDB;user =sa;password=kaka2020";


    public static void AddNewStudents(stStudent Student)
    {
        SqlConnection connection = new SqlConnection(connectionstring);
       
        string qurey = @"insert into Students (FirstName,LastName,Email,Phone,UniversityMajor)
                        values (@FirstName,@LastName,@Email,@Phone,@UniversityMajor) ";

        SqlCommand command = new SqlCommand(qurey, connection);
        command.Parameters.AddWithValue("@FirstName", Student.FirstName);
        command.Parameters.AddWithValue("@LastName", Student.LastName);
        command.Parameters.AddWithValue("@Email", Student.Email);
        command.Parameters.AddWithValue("@Phone", Student.Phone);
        command.Parameters.AddWithValue("@UniversityMajor", Student.UniversityMajor);


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






    public struct stStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UniversityMajor { get; set; }


    }
    public static stStudent ReadNewStudent()
    {
        stStudent student = new stStudent();

        Console.WriteLine("Enter Your FirstName");
        student.FirstName = Console.ReadLine();

        Console.WriteLine("Enter Your LastName");
        student.LastName = Console.ReadLine();

        Console.WriteLine("Enter Your Email");
        student.Email = Console.ReadLine();

        Console.WriteLine("Enter Your Phone");
        student.Phone = Console.ReadLine();

        Console.WriteLine("Enter Your UniversityMajor");
        student.UniversityMajor = Console.ReadLine();

        return student;
    }
    public static void Main()
    {



        
        stStudent student = ReadNewStudent();
        AddNewStudents(student);
        Console.ReadKey();
    }
}