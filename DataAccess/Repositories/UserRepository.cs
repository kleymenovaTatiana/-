using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Repositories 
{
    public class UserRepository : RepositoryBase<Customer>, IUserRepository
    {
        public UserRepository(Практика10Context repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
