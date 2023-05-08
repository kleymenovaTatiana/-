using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services
{
    public class Basket_BuyerService : IBasket_BuyerService 
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Basket_BuyerService(IRepositoryWrapper repositoryWrapper) 
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<BasketBuyer>> GetAll()
        {
            return await _repositoryWrapper.BasketBuyer.FindAll();
        }
        public async Task<BasketBuyer> GetById(int IdUser)
        {
            var basketBuyer = await _repositoryWrapper.BasketBuyer
            .FindByCondition(x => x.IdUser == IdUser);
            return basketBuyer.First();
        }
        public async Task Create(BasketBuyer model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await _repositoryWrapper.BasketBuyer.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(BasketBuyer model)
        {
            _repositoryWrapper.BasketBuyer.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int IdUser)
        {
            var BasketBuyer = await _repositoryWrapper.BasketBuyer
            .FindByCondition(x => x.IdUser == IdUser);
            _repositoryWrapper.BasketBuyer.Delete(BasketBuyer.First());
            _repositoryWrapper.Save();
        }
    }
}
