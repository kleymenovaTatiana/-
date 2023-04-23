using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;

namespace DDomain.Repositories 
{
    public class StaffrRepository : RepositoryBase<staff>, IStaffrRepository 
    {
        public StaffrRepository(ПрактикаЛContext repositoryContext) 
            : base(repositoryContext)
        {
        }
    }
}
