using Contract;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Data
{
    public class EmployeeRepository: RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyContext companyContext): base(companyContext) { }

        public async Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges)=> await FindAll(trackChanges).OrderBy(x=>x.Forenames).ToListAsync();
        public async Task<Employee> GetEmployeeAsync(Guid guid, bool trackChanges) => await FindByCondition(s => s.Id.Equals(guid), trackChanges).FirstOrDefaultAsync();
        public async void CreateEmployee(Employee employee) => Create(employee);
        public async void DeleteEmployee(Employee employee)=> Delete(employee);
    }
}
