using ServerEntity.Bd;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerServer.Bd
{
    public class UserInfo
    {
        [ForeignKey("User")]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateReg { get; set; }
        public User User { get; set; }
    }
}
