using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedEquipCentral.DA.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public DataContext Context
        {
            get { return _dbContext as DataContext; }
        }

        public UserRepository(DataContext context) : base(context) { }
    }
}
