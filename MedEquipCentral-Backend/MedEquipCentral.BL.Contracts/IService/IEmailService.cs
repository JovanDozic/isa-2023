using MedEquipCentral.BL.Contracts.DTO;

namespace MedEquipCentral.BL.Contracts.IService;

public interface IEmailService
{
    Task SendConfirmEmail(UserEmailOptionsDto userEmailOptions);
}