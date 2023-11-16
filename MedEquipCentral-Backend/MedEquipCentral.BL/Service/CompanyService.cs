using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts;
using MedEquipCentral.DA.Contracts.Model;

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

        public void Add(CompanyDto company)
        {
            _unitOfWork.GetCompanyRepository().Add(_mapper.Map<Company>(company));
        }

        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            var companies = await _unitOfWork.GetCompanyRepository().GetAll();
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

    }
}
