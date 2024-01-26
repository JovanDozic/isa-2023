using MedEquipCentral.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;

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
        //public DbSet<AppointmentEquipment> AppointmentEquipment { get; set; }

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
            modelBuilder.Entity<Appointment>()
                .HasMany(e => e.Equipment)
                .WithMany()
                .UsingEntity(j => j.ToTable("AppointmentEquipment"));
            modelBuilder.Entity<Appointment>()
                .HasOne(e => e.Buyer)
                .WithMany()
                //TODO BuyerId == 0 kad se kreira appointment od starne admina kompanije
                .HasForeignKey(e => e.BuyerId);
        }
    }
}
