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
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        //[Key]
        //[ForeignKey("User")]
        public string login { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public bool gender { get; set; }
        public string birthDate { get; set; }
        public string dateReg { get; set; }
        public User User { get; set; }
        //public Task Task { get; set; }
        //public Project Project { get; set; }
    }
}
