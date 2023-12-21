using Microsoft.EntityFrameworkCore;
using PostService.Models;

namespace PostService.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Post { get; set; }
    }
}
