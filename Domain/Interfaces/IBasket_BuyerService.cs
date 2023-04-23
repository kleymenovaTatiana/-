using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IBasket_BuyerService 
    {
        Task<List<BasketBuyer>> GetAll();
        Task<BasketBuyer> GetById(int id);
        Task Create(BasketBuyer model);
        Task Update(BasketBuyer model);
        Task Delete(int id);
    }
}
