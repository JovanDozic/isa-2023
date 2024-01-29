using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts.Helper;
using MedEquipCentral.DA.Contracts.IRepository;
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
            var result = _dbContext.Set<QrCode>().Where(x => x.BuyerId == dataIn.UserId).AsQueryable();

            if (!dataIn.FilterBy.IsNullOrEmpty())
            {
                return result.Where(x => x.AppointmentStatus == x.AppointmentStatus).ToList();
            }

            return await result.ToListAsync();
        }
    }
}
