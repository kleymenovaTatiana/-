using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain.Repositories;

namespace DataAccess.Wrapper 
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Практика10Context _repoContext;

        private IUserRepository _customer;
        public IUserRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new UserRepository(_repoContext);
                }
                return _customer;
            }
        }
        public RepositoryWrapper(Практика10Context repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
