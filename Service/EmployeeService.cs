using Contract;
using Entity;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        public EmployeeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges)
        {
            var employyes = await _repositoryManager.EmployeeRepository.GetAllEmployees(trackChanges);
            return employyes;
        }
    }
}
