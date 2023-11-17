using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
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
        public IEnumerable<CompanyDto> GetAll()
        {
            return _companyService.GetAll();
        }

        [HttpPut]
        public Task<CompanyDto> Update([FromBody] CompanyDto companyDto)
        {
            return _companyService.Update(companyDto);
        }

        [HttpPost]
        public Task<CompanyDto> Add([FromBody] CompanyDto companyDto)
        {
            return _companyService.Add(companyDto);
        }
    }
}
