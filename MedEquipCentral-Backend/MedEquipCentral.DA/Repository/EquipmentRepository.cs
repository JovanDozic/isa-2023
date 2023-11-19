using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;

namespace MedEquipCentral.DA.Repository
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }

        public EquipmentRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<List<Equipment>> GetAllForCompany(int companyId)
        {
            return _dbContext.Set<Equipment>().Where(_dbContext => _dbContext.CompanyIds.Contains(companyId)).ToList();
        }

        public List<Equipment> GetAll()
        {
            return _dbContext.Set<Equipment>()
                             .Include(e => e.Type)
                             .Include(e => e.Companies)
                                 .ThenInclude(company => company.Location)
                             .ToList();
        }

    }
}
