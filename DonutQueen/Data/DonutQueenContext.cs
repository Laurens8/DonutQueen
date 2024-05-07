using DonutQueen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DonutQueen.Areas.Identity.Data;

namespace DonutQueen.Data
{
    public class DonutQueenContext : IdentityDbContext<CustomUser>
    {
       
        public DonutQueenContext(DbContextOptions<DonutQueenContext> option) : base(option)
        {
        }

        public DbSet<Donut> Donuts { get; set; }
        public DbSet<Winkel> Winkels { get; set; }

        public DbSet<WinkelDonut> WinkelsDonut { get; set; }    
        public DbSet<Leverancier> Leveranciers { get; set; }
        public DbSet<LeverancierDonut> LeverancierDonuts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("DonutQueen");

            modelBuilder.Entity<Donut>().ToTable("Donut").Property(p => p.Prijs).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Winkel>().ToTable("Winkel");
            modelBuilder.Entity<WinkelDonut>().ToTable("WinkelDonut");
            modelBuilder.Entity<Leverancier>().ToTable("Leverancier");
            modelBuilder.Entity<LeverancierDonut>().ToTable("LeverancierDonut");

            modelBuilder.Entity<LeverancierDonut>()    // Van LeverancierDonut (*)
              .HasOne(p => p.Leverancier)   // Naar Leverancier (1)
              .WithMany(x => x.LeverancierDonuts)
              .HasForeignKey(p => p.LeverancierId) // foreign key
              .IsRequired();

            modelBuilder.Entity<LeverancierDonut>()    // Van LeverancierDonut (*)
              .HasOne(p => p.Donut)   // Naar Donut (1)
              .WithMany(x => x.LeverancierDonuts)
              .HasForeignKey(p => p.DonutId) // foreign key
              .IsRequired();

             modelBuilder.Entity<WinkelDonut>()    // Van LeverancierDonut (*)
              .HasOne(p => p.Donut)   // Naar Leverancier (1)
              .WithMany(x => x.WinkelDonuts)
              .HasForeignKey(p => p.DonutId) // foreign key
              .IsRequired();

            modelBuilder.Entity<WinkelDonut>()    // Van LeverancierDonut (*)
              .HasOne(p => p.Winkel)   // Naar Donut (1)
              .WithMany(x => x.WinkelDonuts)
              .HasForeignKey(p => p.Winkelid) // foreign key
              .IsRequired();

        }
    }
}