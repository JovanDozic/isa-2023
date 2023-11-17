using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;

namespace MedEquipCentral.DA.Repository
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }

        public LocationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
