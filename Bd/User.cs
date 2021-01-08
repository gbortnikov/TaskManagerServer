using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerEntity.Bd
{
    public class User
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
