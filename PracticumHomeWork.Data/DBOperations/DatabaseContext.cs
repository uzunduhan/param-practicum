using Microsoft.EntityFrameworkCore;
using PracticumHomeWork.Data.Models;
using System.Reflection;

namespace PracticumHomeWork.Data.DBOperations
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        public DbSet<Movie> Movies{get; set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
           .HasOne(x => x.Genre)
           .WithMany(p => p.Movies)
           .IsRequired(false)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}