using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;
using VideoBlock.Persistence.Models;

namespace VideoBlock.Persistence.DbContext
{
    public class VideoBlockDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly string _connectionString = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json")
            .Build()
            .GetConnectionString("SqlServer");

        public VideoBlockDbContext() { }

        public VideoBlockDbContext(DbContextOptions<VideoBlockDbContext> options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacion entre actores y películas
            modelBuilder.Entity<PersonMovie>()
                .HasKey(e => new { e.IdPerson, e.IdMovie });
            modelBuilder.Entity<PersonMovie>()
                .HasOne(e => e.Person)
                .WithMany(e => e.Movies)
                .HasForeignKey(e => e.IdPerson);
            modelBuilder.Entity<PersonMovie>()
                .HasOne(e => e.Movie)
                .WithMany(e => e.Actors)
                .HasForeignKey(e => e.IdMovie);

            // Relación entre películas y usuarios: Reserva de películas
            modelBuilder.Entity<Book>()
                .HasKey(e => new { e.IdUser, e.IdMovie });
            modelBuilder.Entity<Book>()
                .HasOne(e => e.User)
                .WithMany(e => e.Bookings)
                .HasForeignKey(e => e.IdUser);
            modelBuilder.Entity<Book>()
                .HasOne(e => e.Movie)
                .WithMany(e => e.Bookings)
                .HasForeignKey(e => e.IdMovie);

            // Relación enre película y director
            modelBuilder.Entity<Movie>()
                .HasOne(e => e.Director)
                .WithMany(e => e.MoviesDirected)
                .HasForeignKey(e => e.IdDirector);

            // Relación enre usuario y rol
            modelBuilder.Entity<User>()
                .HasOne(e => e.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.IdRole);
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<User> User { get; set; }
    }
}
