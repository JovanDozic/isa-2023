using Microsoft.EntityFrameworkCore;
using MedEquipCentral;

namespace MedEquipCentral.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<MedEquipCentral.Company>? Company { get; set; }
    }
}
