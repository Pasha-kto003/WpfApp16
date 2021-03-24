using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfApp16
{
    class StudentListVM : MvvmNotify, IPageVM
    {
        Model model;
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Group> Groups { get; set; } 
        public Student SelectedStudent
        {
            get => model.SelectedStudent;
            set { model.SelectedStudent = value;
                NotifyPropertyChanged();
            }
        }


        public Group Group { get; set; }
        public MvvmCommand StudentCreate { get; set; }
        public MvvmCommand DeleteStudent { get; set; }
        public MvvmCommand OpenGroupList { get; set; }
        public void SetModel(Model model)
        {

            this.model = model;
            Students = new ObservableCollection<Student>(model.GetStudents());
            Groups = new ObservableCollection<Group>(model.GetGroups()); 
            OpenGroupList = new MvvmCommand(
           () => model.OpenGroupList()
               , () => true);
            DeleteStudent = new MvvmCommand(
           () => model.RemoveStudent()
               , () => true);
            StudentCreate = new MvvmCommand(
            ()=> model.StudentCreate()
                ,() => true);
            
            model.StudentChanged += Model_StudentsChanged;
            PageContainer.CurrentPageChanged += PageContainer_CurrentPageChanged;
        }

        private void PageContainer_CurrentPageChanged(object sender, PageType e)
        {
            Students = new ObservableCollection<Student>(model.GetStudents());
            NotifyPropertyChanged("Students");
        }
        private void Model_StudentsChanged (object sender, PageType e)
        {
            new ObservableCollection<Student>(model.GetStudents());
            NotifyPropertyChanged("Students");
        }
    }
}
