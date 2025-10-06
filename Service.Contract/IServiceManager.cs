using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IServiceManager
    {
        ICsvImportSrvice CsvImportSrvice { get; }
        IEmployeeService EmployeeService { get; }
    }
}
