using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedEquipCentral.BL.Contracts.DTO
{
    public class AuthenticationTokensDto
    {
        public long Id { get; set; }
        public string AccessToken { get; set; }
    }
}
