using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ПрактикаЛContext repositoryContext)
            : base(repositoryContext)
        {
        } 
    }
}
