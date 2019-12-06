using Domain.Projects;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Projects
{
    public sealed class ProjectsDbContext : DbContext
    {
        public ProjectsDbContext(DbContextOptions options) : base(options)
        {
        }

        internal DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property<Guid>("_concurrencyToken").IsConcurrencyToken();
                b.HasMany(u => u.Issues)
                    .WithOne()
                    .HasForeignKey("ProjectId")
                    .HasPrincipalKey(p => p.Id);
            });

            modelBuilder.Entity<Issue>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property<Guid>("ProjectId");
            });
        }
    }
}
