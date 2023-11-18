using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedEquipCentral.Controllers
{
    [Route("api/company")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("getAll")]
        public async Task<List<CompanyDto>> GetAll()
        {
            return await _companyService.GetAll();
        }

        [HttpGet("getById/{id}")]
        public CompanyDto GetById(int id)
        {
            return _companyService.GetById(id);
        }

        [HttpPut]
        public async Task<CompanyDto> Update([FromBody] CompanyDto companyDto)
        {
            return await _companyService.Update(companyDto);
        }

        [HttpPost]
        public Task<CompanyDto> Add([FromBody] CompanyDto companyDto)
        {
            return _companyService.Add(companyDto);
        }

        [HttpPost("getAllBySearch")]
        public Task<PagedResult<CompanyDto>> Search([FromBody] CompanyPagedIn dataIn)
        {
            return _companyService.Search(dataIn);
        }
    }
}
