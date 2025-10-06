using Entity;

namespace Contract
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees(bool trackchanges);
        Task<Employee> GetEmployeeAsync(Guid guid, bool trackchanges);
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
