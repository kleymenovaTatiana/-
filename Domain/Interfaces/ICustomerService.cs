﻿using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICustomerService 
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task Create(Customer model);
        Task Update(Customer model);
        Task Delete(int id);
        Task<Customer> Login(string mail, string password); 
    }
}
