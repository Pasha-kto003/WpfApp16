using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp16
{
    class GroupControl
    {
        public List<Group> Groups { get; set; } = new List<Group>();
        private const string path = "groups.db";
        public GroupControl()
        {
            Groups.Add(new Group { Number = "1125" });
            Groups.Add(new Group { Number = "1115" });
            Groups.Add(new Group { Number = "1121" });
            Groups.Add(new Group { Number = "1131" });
        }
       

    }
}
