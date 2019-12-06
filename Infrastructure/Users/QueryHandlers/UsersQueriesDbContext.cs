using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Users.QueryHandlers
{
    public sealed class UsersQueriesDbContext : DbContext
    {
        public UsersQueriesDbContext(DbContextOptions options) : base(options)
        {
        }

        internal DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(u => u.Id);
            });
        }
    }

    internal sealed class User
    {
        private User() { }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
