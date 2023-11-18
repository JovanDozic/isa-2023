using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Shared;

namespace MedEquipCentral.BL.Contracts.IService
{
    public interface ICompanyService
    {
        public Task<CompanyDto> Add(CompanyDto company);
        Task<List<CompanyDto>> GetAll();
        Task<PagedResult<CompanyDto>> Search(CompanyPagedIn dataIn);
        CompanyDto GetById(int id);
        Task<CompanyDto> Update(CompanyDto companyDto);
    }
}
