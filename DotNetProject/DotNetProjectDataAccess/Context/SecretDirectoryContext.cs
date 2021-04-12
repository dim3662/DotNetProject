using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNetProject.DotNetProjectDataAccess.Context
{
    public partial class SecretDirectoryContext : DbContext
    {
        public SecretDirectoryContext()
        {
        }

        public SecretDirectoryContext(DbContextOptions<SecretDirectoryContext> options)
            : base(options)
        {
        }

        public virtual System.Data.Entity.DbSet<Entities.Message> Messages { get; set; }
        public virtual System.Data.Entity.DbSet<Entities.Secret> Secrets { get; set; }
        public virtual System.Data.Entity.DbSet<Entities.Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Message>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            });

            modelBuilder.Entity<Entities.Secret>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(e => e.CreatedAt).IsRequired();

                entity.Property(e => e.Lifetime).IsRequired();

                entity.HasOne(d => d.Message);
            });

            modelBuilder.Entity<Entities.Person>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.HasOne(d => d.Secret);
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}