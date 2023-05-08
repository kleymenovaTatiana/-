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
    public class StaffrService : IStaffrService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public StaffrService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<staff>> GetAll()
        {
            return await _repositoryWrapper.Staff.FindAll();
        }
        public async Task<staff> GetById(int EmployeeCode)
        {
            var staff = await _repositoryWrapper.Staff
            .FindByCondition(x => x.EmployeeCode == EmployeeCode);
            return staff.First();
        }
        public async Task Create(staff model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.Nickname))
            {
                throw new ArgumentException(nameof(model.Nickname));
            }

            await _repositoryWrapper.Staff.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(staff model)
        {
            _repositoryWrapper.Staff.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int EmployeeCode)
        {
            var staff = await _repositoryWrapper.Staff
            .FindByCondition(x => x.EmployeeCode == EmployeeCode);
            _repositoryWrapper.Staff.Delete(staff.First());
            _repositoryWrapper.Save();
        }
    }
}
