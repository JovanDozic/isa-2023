using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts;
using MedEquipCentral.DA.Contracts.Model;
using MedEquipCentral.DA.Contracts.Shared;
using Microsoft.EntityFrameworkCore;

namespace MedEquipCentral.BL.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CompanyDto> Add(CompanyDto companyDto)
        {
            var companyEntity = _mapper.Map<Company>(companyDto);
            var entityEntry = await _unitOfWork.GetCompanyRepository().Add(companyEntity);

            await _unitOfWork.Save();
            var newCompanyId = entityEntry.Entity.Id;

            await _unitOfWork.GetUserRepository().UpdateCompanyIds(newCompanyId);
            companyDto.Id = newCompanyId;
            return companyDto;
        }


        public IEnumerable<CompanyDto> GetAll()
        {
            var companies = _unitOfWork.GetCompanyRepository().GetAll();
            
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public async Task<PagedResult<CompanyDto>> Search(CompanyPagedIn dataIn)
        {
            var companies = await _unitOfWork.GetCompanyRepository().GetAllBySearch(dataIn);
            var returnDto = _mapper.Map<List<CompanyDto>>(companies);
            return new PagedResult<CompanyDto>()
            {
                result = returnDto,
            };
        }
        public CompanyDto GetById(int id) //IZMENITI DA BUDE POSEBNA FUNKCIJA U COMPANY REPOZITORIJUMU
        {
            var company = _unitOfWork.GetCompanyRepository().GetAll().FirstOrDefault(x => x.Id == id);
            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }

        public async Task<CompanyDto> Update(CompanyDto companyDto)
        {
            _unitOfWork.GetCompanyRepository().Update(_mapper.Map<Company>(companyDto));
            await _unitOfWork.Save();
            return companyDto;
        }
    }
}
