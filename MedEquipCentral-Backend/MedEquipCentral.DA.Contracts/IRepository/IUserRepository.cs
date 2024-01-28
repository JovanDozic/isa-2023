using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MedEquipCentral.DA.Contracts.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        bool CheckPasswordAsync(User? user, string password);
        Task UpdateCompanyIds(int id);
        IEnumerable<User> GetAllByCompanyId(int companyId);
    }
}
