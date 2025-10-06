using Contract;

namespace Data
{
    public class RepositoryManager: IRepositoryManager
    {
        private CompanyContext _companyContext;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        public  RepositoryManager(CompanyContext companyContext)
        {
            _companyContext = companyContext;
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_companyContext));
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;
        public async Task SaveAsync()=>await _companyContext.SaveChangesAsync();
    }
}
