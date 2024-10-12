using System;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using System.Linq;

namespace Studentsmanage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(@"Data Source=localhost\SQLEXPRESS,1433;Initial Catalog=Student Management;Integrated Security=True;")

                    .ShowSql())   
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StudentMap>())  
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))  
                .BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())

            {

                var student = new Student();
                Console.WriteLine("Enter ID");
                student.ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter First Name:");
                student.First_Name = Console.ReadLine();
                Console.WriteLine("Enter Last Name:");
                student.Last_Name = Console.ReadLine();

                Console.WriteLine("Enter Age:");
                student.age = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Department:");
                student.department = Console.ReadLine();


                using (var transaction = session.BeginTransaction())
                {
                    
                    

                    session.Save(student);

                    transaction.Commit();

                    Console.WriteLine("Student added successfully!");
                }

                var students = session.Query<Student>().ToList();
                foreach (var stud in students)
                {
                    Console.WriteLine($"ID: {stud.ID}, Name: {stud.First_Name} {stud.Last_Name}, Age: {stud.age}, Department: {stud.department}");
                }
            }
        }
    }
}
