using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces 
{
    public interface IProducts1Service 
    {
        Task<List<Products1>> GetAll();
        Task<Products1> GetById(int id);
        Task Create(Products1 model);
        Task Update(Products1 model);
        Task Delete(int id);
    }
}
