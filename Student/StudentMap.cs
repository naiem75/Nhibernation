using FluentNHibernate.Mapping;

namespace Studentsmanage
{

    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("student");  // The table name in SQL Server

            Id(x => x.ID).Column("ID").GeneratedBy.Assigned();  // Primary key, using identity (auto-increment)

            Map(x => x.First_Name).Column("First_Name");  // Map 'FirstName' to 'First_Name' column
            Map(x => x.Last_Name).Column("Last_Name");    // Map 'LastName' to 'Last_Name' column
            Map(x => x.age).Column("age");               // Map 'Age' to 'age' column
            Map(x => x.department).Column("department"); // Map 'Department' to 'department' column
        }
    }
}
