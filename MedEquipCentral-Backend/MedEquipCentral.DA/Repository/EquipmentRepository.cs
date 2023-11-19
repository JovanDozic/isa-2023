using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
