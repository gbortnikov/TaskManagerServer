using System;
using System.Data.Entity;
using System.Linq;
using TaskManagerServer.Bd;

namespace ServerEntity.Bd
{
    public class BdContext : DbContext
    {
        // Контекст настроен для использова
        public BdContext()
            : base("DBTaskmanager") { }
        public DbSet<User> users { get; set; }
        public DbSet<UserInfo> userInfos  { get; set; }


    }
}