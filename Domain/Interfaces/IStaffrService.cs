using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces 
{
    public interface IStaffrService
    {
        Task<List<staff>> GetAll();
        Task<staff> GetById(int id);
        Task Create(staff model); 
        Task Update(staff model);
        Task Delete(int id);
    }
}
