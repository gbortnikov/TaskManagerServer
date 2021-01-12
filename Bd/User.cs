using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagerServer.Bd;

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
        public UserInfo Info { get; set; }

    }
}
