namespace MedEquipCentral.BL.Contracts.DTO;
public class UserEmailOptionsDto
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<KeyValuePair<string, string>> Placeholders { get; set; }
}
