using Microsoft.EntityFrameworkCore;
using WebApi.API.Models.Domain;

namespace WebApi.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts{ get; set; }

        public DbSet<Category> Categories { get; set; }


    }
}
