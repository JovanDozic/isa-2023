using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MedEquipCentral.DA.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }

        public UserRepository(DataContext context) : base(context) { }

        public new IEnumerable<User> GetAll()
        {
            return _dbContext.Set<User>().ToList();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public bool CheckPasswordAsync(User? user, string password)
        {
            if (_dbContext.Set<User>().Where(x => x.Id == user.Id && x.Password == password).AsQueryable() != null)
                return true;
            return false;
        }

        public Task UpdateCompanyIds(int companyId)
        {
            var newAdmins = GetAll().Where(x => x.CompanyId == 0);
            foreach (var admin in newAdmins)
            {
                admin.CompanyId = companyId;
            }
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public IEnumerable<User> GetAllByCompanyId(int companyId)
        {
            return GetAll().Where(u => u.CompanyId == companyId);
        }

    }
}
