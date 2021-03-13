using System.ComponentModel.DataAnnotations;
using TaskManagerServer.Bd;
using System.Collections.Generic;

namespace ServerEntity.Bd
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserInfo Info { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Taskk> Taskks { get; set; }
        public User()
        {
            Projects = new List<Project>();
            Taskks = new List<Taskk>();
        }


    }
}
