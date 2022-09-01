using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;

namespace ProjectAPI.DatabaseContext
{
    public class DsnContext : DbContext
    {
        public DsnContext(DbContextOptions<DsnContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
