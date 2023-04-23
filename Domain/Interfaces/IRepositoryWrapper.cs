using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICustomersRepository Customer { get; }
        IBasket_BuyerRepository BasketBuyer { get; }
        ICategoryRepository Category { get; }
        IfilterRepository Filter { get; }
        IOrderRepository Order { get; }
        IProducts1Repository Produts1 { get; }
        IStaffrRepository Staff { get; }
        Task Save();
    }
}
