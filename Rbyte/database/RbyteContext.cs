using Microsoft.EntityFrameworkCore;
using Rbyte.database.Entities;

namespace Rbyte.Database {
    public class RbyteContext : DbContext {
        public DbSet<DbCompany> Companies { get; set; }
        public DbSet<DbPayment> Payments { get; set; }
        public DbSet<DbSubscription> Subscriptions { get; set; }
        public DbSet<DbUser> Users { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql ("server=localhost;database=rByte;user=root;password=admin");
        }

        protected override void OnModelCreating (ModelBuilder builder) {
            base.OnModelCreating (builder);

            builder.Entity<DbCompany> (company => {
                company.ToTable ("Companies");
                company.HasKey (e => e.CompanyId);
                company.Property (e => e.Name).IsRequired ();
                company.Property (e => e.NIP).IsRequired ();
                company.HasOne (x => x.User).WithOne (x => x.Company).HasForeignKey<DbCompany>(x => x.UserId);
            });

            builder.Entity<DbPayment> (payment => {
                payment.ToTable ("Payments");
                payment.HasKey (x => x.PaymentId);
                payment.HasOne (x => x.Subscription).WithMany (x => x.Payments).HasForeignKey (x => x.SubscriptionId);
            });

            builder.Entity<DbSubscription> (subscription => {
                subscription.ToTable ("Subscriptions");
                subscription.HasKey (e => e.SubscriptionId);
            });

            builder.Entity<DbUser> (user => {
                user.ToTable ("Users");
                user.HasKey (x => x.UserId);
            });
        }
    }
}