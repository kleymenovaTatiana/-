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
    public class CategoryService : ICategoryService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public CategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Category>> GetAll()
        {
            return await _repositoryWrapper.Category.FindAll();
        }
        public async Task<Category> GetById(int CategoryId)
        {
            var category = await _repositoryWrapper.Category
            .FindByCondition(x => x.CategoryId == CategoryId);
            return category.First();
        }
        public async Task Create(Category model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.CategoryName))
            {
                throw new ArgumentException(nameof(model.CategoryName));
            }

            await _repositoryWrapper.Category.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Category model)
        {
            _repositoryWrapper.Category.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int CategoryId)
        {
            var Category = await _repositoryWrapper.Category
            .FindByCondition(x => x.CategoryId == CategoryId);
            _repositoryWrapper.Category.Delete(Category.First());
            _repositoryWrapper.Save(); 
        }
    }
}
