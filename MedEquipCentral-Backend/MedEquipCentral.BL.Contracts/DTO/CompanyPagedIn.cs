using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedEquipCentral.BL.Contracts.DTO
{
    public class CompanyPagedIn
    {
        public PageInfo PageInfo { get; set; }
        public CompanyFilter CompanyFilter { get; set; }
    }
}
