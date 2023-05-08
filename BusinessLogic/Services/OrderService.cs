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
    public class OrderService : IOrderService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public OrderService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Order>> GetAll()
        {
            return await _repositoryWrapper.Order.FindAll();
        }
        public async Task<Order> GetById(int OrderCode)
        {
            var order = await _repositoryWrapper.Order
            .FindByCondition(x => x.OrderCode == OrderCode);
            return order.First();
        }
        public async Task Create(Order model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.Status))
            {
                throw new ArgumentException(nameof(model.Status));
            }

            await _repositoryWrapper.Order.Create(model); 
            await _repositoryWrapper.Save();
        }
        public async Task Update(Order model)
        {
            _repositoryWrapper.Order.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int OrderCode)
        {
            var Order = await _repositoryWrapper.Order
            .FindByCondition(x => x.OrderCode == OrderCode);
            _repositoryWrapper.Order.Delete(Order.First());
            _repositoryWrapper.Save();
        }
    }
}
