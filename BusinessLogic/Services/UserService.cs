using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Customer>> GetAll()
        {
            return await _repositoryWrapper.Customer.FindAll();
        }
        public async Task<Customer> GetById(int id)
        {
            var customer = await _repositoryWrapper.Customer 
                .FindByCondition(x => x.ClieNtCode == id);
            return customer.First();
        }
        public async Task Create(Customer model)
        {
            await _repositoryWrapper.Customer.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Customer model)
        {
            _repositoryWrapper.Customer.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)  
        {
            var Customer = await _repositoryWrapper.Customer
                .FindByCondition(x => x.ClieNtCode == id);

            _repositoryWrapper.Customer.Delete(Customer.First());
            _repositoryWrapper.Save();
        }
    }
}
