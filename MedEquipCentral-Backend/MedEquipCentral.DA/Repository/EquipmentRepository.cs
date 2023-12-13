using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            return _dbContext.Set<Equipment>().Where(x => x.CompanyId == companyId).ToList();
        }

        public List<Equipment> GetAll()
        {
            return _dbContext.Set<Equipment>()
                             .Include(e => e.Type)
                             .Include(e => e.Company)
                                 .ThenInclude(company => company.Location)
                             .ToList();
        }

        public async Task<List<Equipment>> GetAllBySearch(EquipmentPagedIn dataIn)
        {
            var result = _dbContext.Set<Equipment>().Where(x => x.CompanyId == dataIn.CompanyId).AsQueryable();

            if (!dataIn.Search.IsNullOrEmpty())
            {
                result = result.Where(x => x.Name.Contains(dataIn.Search));
            }

            return result.ToList();
        }
    }
}
