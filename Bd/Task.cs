using ServerEntity.Bd;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerServer.Bd
{
    public class Taskk
    {
        //[ForeignKey("User")] 
        public int Id { get; set; }
        public string Name { get; set; }
        public int Condition { get; set; }
        public string Description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }




    }
}
