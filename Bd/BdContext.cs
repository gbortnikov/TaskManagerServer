using System;
using System.Data.Entity;
using System.Linq;

namespace ServerEntity.Bd
{
    public class BdContext : DbContext
    {
        // Контекст настроен для использова
        public BdContext()
            : base("DBTaskmanager") { }
        public DbSet<User> users { get; set; }

      
    }
}