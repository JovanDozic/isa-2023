using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Shared;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface ICompanyService
    {
        public Task<CompanyDto> Add(CompanyDto company);
        public IEnumerable<CompanyDto> GetAll();
        public Task<CompanyDto> Update(CompanyDto companyDto);
        Task<PagedResult<CompanyDto>> Search(CompanyPagedIn dataIn);
    }
}
