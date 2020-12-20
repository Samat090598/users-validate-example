using Microsoft.EntityFrameworkCore;

namespace UsersExample.Models.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; } 
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
    }
}