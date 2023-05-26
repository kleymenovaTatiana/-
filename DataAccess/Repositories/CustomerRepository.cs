using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomersRepository
    {
        public CustomerRepository(ПрактикаЛContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<Customer?> GetByEmailAndPassword(string mail, string password)
        {
            var result = await base.FindByCondition(x => x.Mail == mail && x.Password == password);
            if (result == null || result.Count == 0)
            {
                return null;
            }

            return result[0];
        }
    } 
}
