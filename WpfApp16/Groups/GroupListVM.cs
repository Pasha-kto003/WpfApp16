using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp16
{
    class GroupListVM : MvvmNotify, IPage
    {
        public void OpenGroupList()
        {
            
        }

        Model model;
        List<Group> Groups = new List<Group>
        {
            new Group {Number = "1125"},
            new Group {Number = "1131"}
        };

        public void SetVM(IPageVM vm)
        {
            this.model = model;
        }
    }
}
