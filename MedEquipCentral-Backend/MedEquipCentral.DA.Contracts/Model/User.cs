#nullable disable
using MedEquipCentral.DA.Contracts.Shared;
using Microsoft.Extensions.Options;

namespace MedEquipCentral.DA.Contracts.Model
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Job { get; set; }
        public string CompanyInfo { get; set; }
        public UserRole Role { get; set; }
        public int? CompanyId { get; set; }

        public User(string email, string password, string name, string surname, string city, string country, string phone, string job, string companyInfo, UserRole role)
        {
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
            City = city;
            Country = country;
            Phone = phone;
            Job = job;
            CompanyInfo = companyInfo;
            Role = role;
            Validate();
        }
        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Email)) throw new ArgumentException("Invalid Username");
            if (string.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Invalid Password");
        }

        public string GetPrimaryRoleName()
        {
            return Role.ToString().ToLower();
        }
    }
}
