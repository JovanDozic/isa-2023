using MedEquipCentral.BL.Contracts.DTO;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface ICompanyService
    {
        public void Add(CompanyDto company);
        public Task<IEnumerable<CompanyDto>> GetAllAsync();
        public Task<CompanyDto> Update(CompanyDto companyDto);
    }
}
