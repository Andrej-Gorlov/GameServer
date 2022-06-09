using GameServer.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GameServer.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Server>? Servers { get; set; }
    }
}
