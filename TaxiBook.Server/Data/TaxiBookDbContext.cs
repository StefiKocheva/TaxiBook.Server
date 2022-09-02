namespace TaxiBook.Server.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TaxiBook.Server.Data.Models;

    public class TaxiBookDbContext : IdentityDbContext<User>
    {
        public TaxiBookDbContext(DbContextOptions<TaxiBookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Company>()
                .HasOne(c => c.User)
                .WithMany(u => u.Companies)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}