using MedEquipCentral.BL.Contracts.DTO;

namespace MedEquipCentral.BL.Contracts.IService;

public interface IEmailService
{
    Task SendVerficationEmail(UserEmailOptionsDto userEmailOptions);
    Task SendAppointmentConfirmationEmail(UserEmailOptionsDto userEmailOptions, string path);
}