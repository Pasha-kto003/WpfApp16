using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp16
{
    class StudentCreateVM: MvvmNotify, IPageVM
    {
        public MvvmCommand CreateStudent { get; set; }
        public MvvmCommand Back { get; set; }
        public MvvmCommand EditStudent { get; set; }      
        Model model;
        public Student SelectedStudent
        {
            get => model.SelectedStudent;
            set => model.SelectedStudent = value;
        }
        public void SetModel(Model model)
        {
            this.model = model;
            CreateStudent = new MvvmCommand(
            () => model.CreateStudent()
                , () => true);
            Back = new MvvmCommand(
            () => model.Back()
                , () => true);
            EditStudent = new MvvmCommand(
            () => model.EditStudent(SelectedStudent)
                , () => true);
            model.SelectedStudentChanged += Model_SelectedStudentChanged;
        }
        private void Model_SelectedStudentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("SelectedStudent");
            NotifyPropertyChanged("SelectedStudentChanged");
        }
    }
}
