using ServerEntity.Bd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerServer.Bd
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Taskk> Taskks { get; set; }
        public ICollection<User> Users { get; set; }
        public Project()
        {
            Users = new List<User>();
            Taskks = new List<Taskk>();
        }
    }
}
