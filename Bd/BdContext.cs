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
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Taskk> Taskks { get; set; }
        public DbSet<Project> Projects { get; set; }


    }
}