using Microsoft.EntityFrameworkCore;
using WebAppbotbeer.Data.Entities;
namespace WebAppbotbeer.Data
{
    public class Context : DbContext
    {
        private readonly IConfiguration _configuration;
        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("SqlServer");
            optionsBuilder.UseSqlServer(connectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DrinkEntry>()
                .HasOne(d => d.User)
                .WithMany(u => u.DrinkEntries)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<LocationData> Locations { get; set; }
        public DbSet<DrinkEntry> DrinkEntries { get; set; }
    }
}
