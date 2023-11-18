namespace MedEquipCentral.DA.Contracts.Model;

public class UserEmailOptions
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<KeyValuePair<string, string>> Placeholders{ get; set; }
}
