using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManager.Entitis;

namespace ZooManager.EFPersistance
{
    internal class EFContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Zoo> Zoos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=.; Initial Catalog= ZooManagerDB;Integrated Security=true;" +
                "Trust Server Certificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //Zoo
            modelbuilder.Entity<Zoo>().ToTable("Zoos");
            modelbuilder.Entity<Zoo>().HasKey(_ => _.Id);
            modelbuilder.Entity<Zoo>().Property(_=>_.Id).UseIdentityColumn();
            modelbuilder.Entity<Zoo>().Property(_ => _.Name) 
                .IsRequired()
                .HasMaxLength(20);
            modelbuilder.Entity<Zoo>().Property(_=>_.Adres)
                .IsRequired()
                .HasMaxLength(100);
            modelbuilder.Entity<Zoo>().Property(_ => _.PartNumber)
                .IsRequired();
            modelbuilder.Entity<Zoo>()
                .HasMany(_=>_.parts)
                .WithOne(_=>_.zoo)
                .HasForeignKey(_=>_.ZooId);
            //Part
            modelbuilder.Entity<Part>().ToTable("parts");
            modelbuilder.Entity<Part>().HasKey(_ => _.Id);
            modelbuilder.Entity<Part>().Property(_ => _.Id)
                .UseIdentityColumn();
            modelbuilder.Entity<Part>().Property(_ => _.Area)
                .IsRequired()
                .HasDefaultValue(0);
            modelbuilder.Entity<Part>().Property(_ => _.AnimalCount)
                .HasDefaultValue(0);
            modelbuilder.Entity<Part>()
                .HasOne(p => p.Animal)
                .WithOne(p => p.Part)
                .HasForeignKey<Animal>(_ => _.PartId);
            modelbuilder.Entity<Part>()
                .HasMany(_=>_.tickets)
                .WithOne(_=>_.Part)
                .HasForeignKey(_=>_.PartId);
            //Ticket
            modelbuilder.Entity<Ticket>().ToTable("Tickets");
            modelbuilder.Entity<Ticket>().HasKey(_ => _.Id);
            modelbuilder.Entity<Ticket>().Property(_ => _.Id)
                .UseIdentityColumn();
            modelbuilder.Entity<Ticket>().Property(_ => _.Price)
                .IsRequired()
                .HasDefaultValue(0);
            modelbuilder.Entity<Ticket>()
                .HasOne(_ => _.Part)
                .WithMany(_ => _.tickets)
                .HasForeignKey(p => p.PartId);
            //Animals
            modelbuilder.Entity<Animal>().ToTable("Animals");
            modelbuilder.Entity<Animal>().HasKey(_ => _.Id);
            modelbuilder.Entity<Animal>().Property(_ => _.AnimalType)
                .IsRequired()
                .HasMaxLength(100);
            modelbuilder.Entity<Animal>().Property(_ => _.AnimalNumber)
                .IsRequired()
                .HasDefaultValue(0);
            modelbuilder.Entity<Animal>().Property(_ => _.Description)
                .IsRequired();
            modelbuilder.Entity<Animal>()
                .HasOne(_ => _.Part)
                .WithOne(_ => _.Animal)
                .HasForeignKey<Animal>(_ => _.PartId);
                
                






        }
    }
}
