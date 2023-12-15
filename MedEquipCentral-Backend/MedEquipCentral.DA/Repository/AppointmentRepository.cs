using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;

namespace MedEquipCentral.DA.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }
        public AppointmentRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<List<Appointment>> GetFreeAppointments(int companyId)
        {
            var result = _dbContext.Set<Appointment>().Where(x => x.CompanyId == companyId && x.BuyerId == 0).Include(x => x.Equipment).ToList();

            return result;
        }

        public async Task<List<Appointment>> GetAllForEquipment(int equipmentId)
        {
            var result = _dbContext.Set<Appointment>().Where(x => x.EquipmentIds.Contains(equipmentId)).ToList();

            return result;
        }

        public async Task<List<Appointment>> GetAllByCompany(int companyId)
        {
            var result = _dbContext.Set<Appointment>().Where(x => x.CompanyId == companyId).ToList();

            return result;
        }
    }
}
