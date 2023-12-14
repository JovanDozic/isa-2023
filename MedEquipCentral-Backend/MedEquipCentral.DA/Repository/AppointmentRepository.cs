using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Contracts.Model;
using MedEquipCentral.DA.Contracts.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
