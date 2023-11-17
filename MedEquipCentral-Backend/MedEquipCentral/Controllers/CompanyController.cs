﻿using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts.Shared;
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

        [HttpGet("getById/{id}")]
        public async Task<CompanyDto> GetByIdAsync(int id)
        {
            return await _companyService.GetById(id);
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

        [HttpPost("search")]
        public Task<PagedResult<CompanyDto>> Search(CompanyPagedIn dataIn)
        {
            return _companyService.Search(dataIn);
        }
    }
}
