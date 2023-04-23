using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Repositories
{
    public class Products1Repository : RepositoryBase<Products1>, IProducts1Repository
    {
        public Products1Repository(ПрактикаЛContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
