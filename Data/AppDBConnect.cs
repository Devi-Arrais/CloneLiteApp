using Microsoft.EntityFrameworkCore;
using CloneLiteApp.Models;

namespace CloneLiteApp.Data
{
    public class AppDBConnect : DbContext
    {
        public AppDBConnect(DbContextOptions<AppDBConnect> options) : base(options){}
        public DbSet<Produtos> Produtos => Set<Produtos>();
        public DbSet<User> User => Set<User>();

    }
}