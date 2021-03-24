using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp16
{
     class StudentControl
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Group> Groups { get; set; } = new List<Group>();
        
        public StudentControl()
        {
            Students.Add(new Student { Name = "Andrew", FatherName="Pakovski", LastName="Woods", Address = "Warsaw Poland" });
        }
        
        internal void EditStudent( )
        {
            
        }

        internal Student CreateStudent(Student student)
        {
            Student newStudent = new Student { Name = "Alex", FatherName= "Pakovski", LastName= "Pakovski", Address = "Warsaw Poland" };
            Students.Add(newStudent);
            return newStudent;
        }

        internal void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }
        

    }
}
