using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Student_Management_Project
{
    public class student
    {
        //private string name;
        //private DateTime dateOfBirth;
        //private string rollNumber;

        public string Name                // Properties
        {
            get;
           private set;
        }
        public DateTime DateOfBirth        // Properties
        {
            get;
           private set;
        }

        public string RollNumber           // Properties
        {
            get;
           private set;
        }

        public student(string name, DateTime dateOfBirth, string rollNumber) //constructor
        {
            ValidatesInput(name, dateOfBirth, rollNumber);

            Name = name;
            DateOfBirth = dateOfBirth;
            RollNumber = rollNumber;
        }  

        private static void ValidatesInput(string name, DateTime dateOfBirth, string rollNumber)
        {
            if (dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException("Invalid Date");          // Exception handling
            }
            if (dateOfBirth == default)
            {
                throw new ArgumentException("Date of Birth can't be null");          // Exception handling
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name can't be null");
            }
            if (string.IsNullOrEmpty(rollNumber))
            {
                throw new ArgumentException("Roll Number can't be null");
            }
        }

        private int CalculateAge()                      // age calculating method
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            return age;
        }

        public int Age => CalculateAge();                        // age calculating properties
        //{
        //    get { return CalculateAge(); }
        //}

        public void PrintDetails()            // print method
        {
            Console.WriteLine($"Name : {Name}, Date of Birth : " +
                $"{DateOfBirth.ToShortDateString()}, RollNumber : {RollNumber}," +
                $" Age : {Age}");
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                student s1 = new student("Alex Hales", new DateTime(1990, 3, 21),
                    "CSE101");
                student s2 = new student("Jimmy Nisham", new DateTime(1992, 5, 30),
                    "CSE102");

     
                Console.WriteLine("Student Details");
                Console.WriteLine("---------------");   // Display Student details
                s1.PrintDetails();
                s2.PrintDetails();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
