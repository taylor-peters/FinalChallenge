using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;



namespace FinalChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentContext())
            {
                // Create and save a new Student
                Console.Write("Enter a name for the new student: ");
                var name = Console.ReadLine();

                var student = new Student { Name = name };
                db.Students.Add(student);
                db.SaveChanges();

                // Display all students from the database
                var query = from b in db.Students
                            orderby b.Name
                            select b;

                Console.WriteLine("All students in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

    }


    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
