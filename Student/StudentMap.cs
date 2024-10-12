using FluentNHibernate.Mapping;

namespace Studentsmanage
{

    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("student");  

            Id(x => x.ID).Column("ID").GeneratedBy.Assigned();  

            Map(x => x.First_Name).Column("First_Name");  
            Map(x => x.Last_Name).Column("Last_Name");    
            Map(x => x.age).Column("age");               
            Map(x => x.department).Column("department"); 
        }
    }
}
