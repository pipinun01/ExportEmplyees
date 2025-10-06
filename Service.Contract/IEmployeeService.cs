using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges);
    }
}
