using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICustomersRepository : IRepositoryBase<Customer>
    {
        public Task<Customer?> GetByEmailAndPassword(string mail, string password); 
    }
}
