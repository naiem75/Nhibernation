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
                using (var transaction = session.BeginTransaction())
                {
                    var student = new Student
                    {
                        ID = 4,
                        First_Name = "rasel",
                        Last_Name = "mahmud",
                        age = 22,
                        department = "Computer Science"
                       
                    };

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
