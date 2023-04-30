using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public CustomerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Customer>> GetAll()
        {
            return await _repositoryWrapper.Customer.FindAll();
        }
        public async Task<Customer> GetById(int ClieNtCode)
        {
            var customer = await _repositoryWrapper.Customer
            .FindByCondition(x => x.ClieNtCode == ClieNtCode);
            return customer.First();
        }
        public async Task Create(Customer model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.Nickname))
            {
                throw new ArgumentException(nameof(model.Nickname)); 
            }

            await _repositoryWrapper.Customer.Create(model);
            await _repositoryWrapper.Save(); 
        }
        public async Task Update(Customer model)
        {
            _repositoryWrapper.Customer.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int ClieNtCode)
        {
            var Customer = await _repositoryWrapper.Customer
            .FindByCondition(x => x.ClieNtCode == ClieNtCode);
            _repositoryWrapper.Customer.Delete(Customer.First());
            _repositoryWrapper.Save();
        }
    }
}

