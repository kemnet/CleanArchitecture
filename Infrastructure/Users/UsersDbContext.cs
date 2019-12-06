using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Users
{
    public sealed class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {
        }

        internal DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(u => u.Id);
                b.Property<Guid>("_concurrencyToken").IsConcurrencyToken();
                b.HasMany(u => u.Projects)
                    .WithOne()
                    .HasForeignKey("UserId")
                    .HasPrincipalKey(u => u.Id);
            });

            modelBuilder.Entity<Project>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property<Guid>("UserId");
            });
        }
    }
}
