using Microsoft.EntityFrameworkCore;
using MedEquipCentral.DA.Contracts.Model;

namespace MedEquipCentral.DA.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Company>? Company { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentType> EquipmentType { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasOne(c => c.Location)
                .WithMany()
                .HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Type)
                .WithMany()
                .HasForeignKey(e => e.TypeId);
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Company)
                .WithMany()
                .HasForeignKey(e => e.CompanyId);
        }
    }
}
