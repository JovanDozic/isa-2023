﻿using MedEquipCentral.DA.Contexts;
using MedEquipCentral.DA.Contracts.IRepository;
using MedEquipCentral.DA.Contracts.Model;

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
