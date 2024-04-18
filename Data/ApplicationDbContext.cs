using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimimInnovation.Models;

namespace TimimInnovation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TimimBCProperties> TimimProperties { get; set; }
        public DbSet<TimimAgent> TimimAgents { get; set; }
        public DbSet<TimimTransaction> TimimTransactions { get; set; }
        public DbSet<TermAndCondition> TermAndConditions { get; set; }
        public DbSet<Concord> Concords { get; set; }
        public DbSet<ClientConcord> ClientConcords { get; set; }
        public DbSet<ClientTermAndCondition> ClientTermAndConditions { get; set; }
        public DbSet<LastActivity> LastActivities { get; set; }
        public DbSet<TimimComplaintBox> TimimComplaintBoxes { get; set; }
        public DbSet<TenantComplain> TenantComplains { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration for TimimTransaction's Price property
            modelBuilder.Entity<TimimTransaction>()
                .Property(t => t.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
