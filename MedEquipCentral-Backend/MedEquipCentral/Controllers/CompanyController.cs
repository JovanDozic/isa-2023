﻿using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedEquipCentral.Controllers
{
    [Route("api/company")]
    [Authorize(Policy = "allRolesPolicy")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("getAll")]
        [AllowAnonymous]
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
        [Authorize(Policy = "companyAdminPolicy")]
        public async Task<CompanyDto> Update([FromBody] CompanyDto companyDto)
        {
            return await _companyService.Update(companyDto);
        }

        [HttpPost]
        [Authorize(Policy = "systemAdminPolicy")]
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
