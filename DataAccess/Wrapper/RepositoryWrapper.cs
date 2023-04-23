using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DDomain.Repositories;
using Domain.Interfaces;
using Domain.Models;
using Domain.Repositories;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ПрактикаЛContext _repoContext; 

        private ICustomersRepository _customer;
        public ICustomersRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_repoContext);
                }
                return _customer;
            }
        }

        private IBasket_BuyerRepository _basketBuyer; 
        public IBasket_BuyerRepository BasketBuyer
        {
            get
            {
                if (_basketBuyer == null)
                {
                    _basketBuyer = new Basket_BuyerRepository(_repoContext);
                }
                return _basketBuyer;
            }
        }

        private ICategoryRepository _category;
        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }
                return _category;
            }
        }

        private IfilterRepository _filter;
        public IfilterRepository Filter
        {
            get
            {
                if (_filter == null)
                {
                    _filter = new filterRepository(_repoContext);
                }
                return _filter;
            }
        }

        private IOrderRepository _Order;
        public IOrderRepository Order
        {
            get
            {
                if (_Order == null)
                {
                    _Order = new OrderRepository(_repoContext);
                }
                return _Order;
            }
        }

        private IProducts1Repository _products1;  
        public IProducts1Repository Produts1 
        {
            get
            {
                if (_products1 == null)
                {
                    _products1 = new Products1Repository(_repoContext);
                }
                return _products1;
            }
        }

        private IStaffrRepository _staff;
        public IStaffrRepository Staff 
        {
            get
            {
                if (_staff == null)
                {
                    _staff = new StaffrRepository(_repoContext);
                }
                return _staff;
            }
        }

        public RepositoryWrapper(ПрактикаЛContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
