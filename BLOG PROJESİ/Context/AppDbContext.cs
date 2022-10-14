using BLOG_PROJESİ.Models.Entites.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BLOG_PROJESİ.Context
{
    public class AppDbContext : DbContext
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
