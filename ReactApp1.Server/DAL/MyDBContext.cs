using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReactApp1.Server.Models;
using System.Reflection.Metadata;

namespace ReactApp1.Server.DAL
{
    public class MyDBContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            
        //    optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=postgres;Database=postgres");
        //}
    }
}
