using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp16
{
    public class Model
    {
        Student selectedStudent;
        StudentControl studentControl = new StudentControl();
        GroupControl groupControl = new GroupControl();

        public Student SelectedStudent { get => selectedStudent; internal set { selectedStudent = value; SelectedStudentChanged?.Invoke(this, null); } }
        public Action<object, PageType> StudentChanged { get; internal set; }
        


        public event EventHandler SelectedStudentChanged;
        public event EventHandler StudentsChanged;
        internal List<Group> GetGroups()
        {
            return groupControl.Groups;
        }
        internal List<Student> GetStudents()
        {
            return studentControl.Students;
        }
        internal void EditStudent(Student student)
        {
            SelectedStudent = student;
            PageContainer.ChangePageTo(PageType.StudentList);
            StudentsChanged?.Invoke(this, null);
        }
        internal void CreateStudent()
        {
            SelectedStudent = studentControl.CreateStudent();
            PageContainer.ChangePageTo(PageType.StudentList);
            StudentsChanged?.Invoke(this, null);
        }

        internal void Back()
        {
            PageContainer.ChangePageTo(PageType.StudentList);
        }

        internal void RemoveStudent()
        {
            studentControl.RemoveStudent(SelectedStudent);
            StudentsChanged?.Invoke(this, null);
        }
        internal void StudentCreate()
        {
            PageContainer.ChangePageTo(PageType.StudentCreate);
        }
        internal void OpenGroupList()
        {
            PageContainer.ChangePageTo(PageType.GroupList);
        }

    }
}
