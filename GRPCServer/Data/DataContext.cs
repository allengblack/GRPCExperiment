using GRPCServer.Models;
using Microsoft.EntityFrameworkCore;

namespace GRPCServer.Data
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
     : base(options)
        { }

        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=users.db");
    }
}
