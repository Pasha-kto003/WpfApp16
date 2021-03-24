using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WpfApp16
{
    class MainVM : MvvmNotify
    {
        Model model;

        public Page CurrentPage { get;set; }

        public MvvmCommand OpenGroupList { get; set; }
        public MvvmCommand OpenStudentList { get; set; }

        public MainVM()
        {
            model = new Model();
            PageContainer.SetModel(model);
            CurrentPage = PageContainer.GetPageByType(PageType.StudentList);
            PageContainer.CurrentPageChanged += PageContainer_CurrentPageChanged;
            OpenGroupList = new MvvmCommand(() => PageContainer.ChangePageTo(PageType.GroupList), () => true);
            OpenStudentList = new MvvmCommand(() => PageContainer.ChangePageTo(PageType.StudentList), () => true);
        }

        void PageContainer_CurrentPageChanged(object sender, PageType e)
        {
            CurrentPage = PageContainer.GetPageByType(e);
            NotifyPropertyChanged("CurrentPage");
        }
    }
}
