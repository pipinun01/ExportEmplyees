using Contract;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager: IServiceManager
    {
        private readonly Lazy<ICsvImportSrvice> csvImportSrvice;
        private readonly Lazy<IEmployeeService> employeeService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            csvImportSrvice = new Lazy<ICsvImportSrvice>(()=>new CsvImportSrvice(repositoryManager));
            employeeService = new Lazy<IEmployeeService>(()=>new EmployeeService(repositoryManager));

        }
        public ICsvImportSrvice CsvImportSrvice => csvImportSrvice.Value;
        public IEmployeeService EmployeeService => employeeService.Value;
    }
}
