using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts.Helper;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Contracts.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MedEquipCentral.DA.Repository
{
    public class QrCodeRepository : Repository<QrCode>, IQrCodeRepository
    {
        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }
        public QrCodeRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<QrCode> GetByAppointmentId(int appointmentId)
        {
            return await _dbContext.Set<QrCode>().FirstOrDefaultAsync(x => x.AppointmentId == appointmentId);
        }

        public async Task<List<QrCode>> GetByUserId(QrCodeDataIn dataIn)
        {
            var result = _dbContext.Set<QrCode>().Where(x => x.BuyerId == dataIn.UserId || x.AdminId == dataIn.UserId).AsQueryable();

            if (!dataIn.FilterBy.IsNullOrEmpty())
            {
                switch (dataIn.FilterBy)
                {
                    case "New":
                        result = result.Where(x => x.AppointmentStatus == Contracts.Model.AppointmentStatus.NEW);
                        break;
                    case "Processed":
                        result = result.Where(x => x.AppointmentStatus == Contracts.Model.AppointmentStatus.PROCESSED);
                        break;
                    case "Cancelled":
                        result = result.Where(x => x.AppointmentStatus == Contracts.Model.AppointmentStatus.CANCELLED);
                        break;
                    default:
                        result = result.Where(x => x.AppointmentStatus == Contracts.Model.AppointmentStatus.EXPIRED);
                        break;
                }
            }

            return await result.ToListAsync();
        }
    }
}
