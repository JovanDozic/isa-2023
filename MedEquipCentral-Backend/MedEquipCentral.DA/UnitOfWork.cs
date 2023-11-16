using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Repository;

namespace MedEquipCentral.DA
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;

        public UnitOfWork(DataContext context) 
        {
            _context = context;
        }

        private IUserRepository UserRepository { get; set; }
        private ICompanyRepository CompanyRepository { get; set; }

        public async void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _context?.Dispose();

            _context = null;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public IUserRepository GetUserRepository()
        {
            return UserRepository ?? (UserRepository = new UserRepository(_context));
        }

        public ICompanyRepository GetCompanyRepository()
        {
            return CompanyRepository ?? (CompanyRepository = new CompanyRepository(_context));
        }
    }
}
