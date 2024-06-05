using Domain.Entities;
using Domain.Entities.Relationships;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Progress> Progress { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<TrainingRoutines> TrainingRoutines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TrainingRoutines>().HasKey(tr => new { tr.TrainingId, tr.RoutineId });


            builder.Entity<Training>()
                .HasOne(t => t.Person)
                .WithMany(t => t.Training)
                .HasForeignKey(x => x.PersonId);

            builder.Entity<Person>()
                .HasOne(x => x.Progress)
                .WithOne(x => x.Person)
                .HasForeignKey<Progress>(x => x.PersonId);
        }
    }
}