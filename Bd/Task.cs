using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerServer.Bd
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Condition { get; set; }
        public int Description { get; set; }
        public Project Project { get; set; }
        public UserInfo UserInfo { get; set; }




    }
}
