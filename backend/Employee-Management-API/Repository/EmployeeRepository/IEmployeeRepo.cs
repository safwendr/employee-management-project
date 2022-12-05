using Employee_Management_API.Models;
using Employee_Management_API.Models.Responses;

namespace Employee_Management_API.Repository.EmployeeRepository
{
    public interface IEmployeeRepo
    {
        public Task<EmployeeResponseDetails> getAllEmployee();
        public Task<EmployeeResponseDetails> getSingleEmployee(int employeeId);
        public Task<EmployeeResponseDetails> createEmployee(Employee employee);
        public Task<EmployeeResponseDetails> updateEmployee(int employeeId, Employee employee);
        public Task<EmployeeResponseDetails> deleteEmployee(int EmployeeId);
    }
}
