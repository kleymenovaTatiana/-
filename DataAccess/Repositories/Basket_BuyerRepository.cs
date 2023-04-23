using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Repositories
{
    public class Basket_BuyerRepository : RepositoryBase<BasketBuyer>, IBasket_BuyerRepository
    { 
        public Basket_BuyerRepository(ПрактикаЛContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
