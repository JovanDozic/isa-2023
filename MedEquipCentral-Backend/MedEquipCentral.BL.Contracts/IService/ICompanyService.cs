using MedEquipCentral.BL.Contracts.DTO;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface ICompanyService
    {
        public Task<CompanyDto> Add(CompanyDto company);
        public IEnumerable<CompanyDto> GetAll();
        public Task<CompanyDto> Update(CompanyDto companyDto);
    }
}
