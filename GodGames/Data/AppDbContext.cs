using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GodGames.Models;

namespace GodGames.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<VideoGames> VideoGames { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGames>().ToTable("VideoGames");

            modelBuilder.Entity<Imagen>().ToTable("Imagenes");

            modelBuilder.Entity<Imagen>()
                .Property(i => i.IdVideogames)
                .HasColumnName("IdVideogames"); 
        } 
    } 
} 