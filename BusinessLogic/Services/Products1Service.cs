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
    public class Products1Service : IProducts1Service
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Products1Service(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Products1>> GetAll()
        {
            return await _repositoryWrapper.Produts1.FindAll();
        }
        public async Task<Products1> GetById(int LtemNumber)
        {
            var products1 = await _repositoryWrapper.Produts1
            .FindByCondition(x => x.LtemNumber == LtemNumber);
            return products1.First();
        }
        public async Task Create(Products1 model)
        {
            await _repositoryWrapper.Produts1.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Products1 model)
        {
            _repositoryWrapper.Produts1.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int LtemNumber)
        {
            var Products1 = await _repositoryWrapper.Produts1
            .FindByCondition(x => x.LtemNumber == LtemNumber);
            _repositoryWrapper.Produts1.Delete(Products1.First());
            _repositoryWrapper.Save();
        }
    }
}
