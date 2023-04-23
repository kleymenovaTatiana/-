using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IfilterService 
    {
        Task<List<Filter>> GetAll();
        Task<Filter> GetById(int id);
        Task Create(Filter model);
        Task Update(Filter model); 
        Task Delete(int id);
    }
}
