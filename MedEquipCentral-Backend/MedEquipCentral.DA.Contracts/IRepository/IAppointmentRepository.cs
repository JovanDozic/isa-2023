using MedEquipCentral.DA.Contracts.Model;

namespace MedEquipCentral.DA.Contracts.IRepository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<List<Appointment>> GetFreeAppointments(int companyId);
        Task<List<Appointment>> GetAllForEquipment(int equipmentId);
        Task<List<Appointment>> GetAllByCompany(int companyId);
    }
}
