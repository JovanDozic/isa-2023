using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Model;
namespace MedEquipCentral.DA.Contracts.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        public new IEnumerable<Company> GetAll();
        Task<List<Company>> GetAllBySearch(CompanyPagedIn dataIn);
    }
}
