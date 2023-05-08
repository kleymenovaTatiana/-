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
    public class filterService : IfilterService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public filterService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Filter>> GetAll()
        {
            return await _repositoryWrapper.Filter.FindAll();
        }
        public async Task<Filter> GetById(int CategoryId)
        {
            var filter = await _repositoryWrapper.Filter
            .FindByCondition(x => x.CategoryId == CategoryId);
            return filter.First();
        }
        public async Task Create(Filter model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.Feed))
            {
                throw new ArgumentException(nameof(model.Feed));
            }

            await _repositoryWrapper.Filter.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Filter model)
        {
            _repositoryWrapper.Filter.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int CategoryId)
        {
            var Filter = await _repositoryWrapper.Filter
            .FindByCondition(x => x.CategoryId == CategoryId);
            _repositoryWrapper.Filter.Delete(Filter.First());
            _repositoryWrapper.Save();
        }
    }
}
