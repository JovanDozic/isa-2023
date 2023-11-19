using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;

namespace MedEquipCentral.DA.Repository
{
    public class EquipmentTypeRepository : Repository<EquipmentType>, IEquipmentTypeRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }

        public EquipmentTypeRepository(DbContext dbContext) : base(dbContext) { }

        List<EquipmentType> IEquipmentTypeRepository.GetAll()
        {
            return _dbContext.Set<EquipmentType>().ToList();
        }
    }
}
