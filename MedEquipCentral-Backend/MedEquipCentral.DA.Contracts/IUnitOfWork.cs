using MedEquipCentral.DA.Contracts.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedEquipCentral.DA.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Save();
        public IUserRepository GetUserRepository();
        public ICompanyRepository GetCompanyRepository();
        public ILocationRepository GetLocationRepository();
        public ITokenGeneratorRepository GetTokenGeneratorRepository();
    }
}
