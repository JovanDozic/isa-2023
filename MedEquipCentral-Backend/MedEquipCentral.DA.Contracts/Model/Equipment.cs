using MedEquipCentral.DA.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedEquipCentral.DA.Contracts.Model
{
    public class Equipment : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public string Type { get; set; }
        public int CompanyId { get; set; }

        public Equipment(string name, string description, int companyId)
        {
            Name = name;
            Description = description;
            CompanyId = companyId;
            //Validate();
        }

        private void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
