using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Contracts.Model;

namespace MedEquipCentral.DA.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {

        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }

        public CompanyRepository(DataContext context) : base(context) { }

    }
}
