using Employee_Management_API.Data;
using Employee_Management_API.Models;
using Employee_Management_API.Models.Responses;
using MessagePack.Formatters;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_API.Repository.EmployeeRepository
{
    public class EmployeeRepo : IEmployeeRepo
    {

        private readonly employeemanagementdbContext _context;
        public EmployeeRepo(
            employeemanagementdbContext context
            )
        {
            _context = context;
        }
        public async Task<EmployeeResponseDetails> createEmployee(Employee employee)
        {
            var employeeResponse = new EmployeeResponseDetails();
            try
            {
                if (employee == null)
                {
                    employeeResponse.Success = false;
                    return employeeResponse;
                }
                var res = await _context.AddAsync(employee);
                _context.SaveChanges();
                employeeResponse.Success = true;
                employeeResponse.SingleEmployee = employee;
                return employeeResponse;
            }
            catch (Exception ex)
            {
                employeeResponse.Exception = ex.Message;
                employeeResponse.Success = false;
                return employeeResponse;
            }
        }

        public async Task<EmployeeResponseDetails> deleteEmployee(int employeeId)
        {
            var employeeResponse = new EmployeeResponseDetails();
            if (employeeId == null)
            {
                employeeResponse.Success = false;
                return employeeResponse;
            }
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
            if (employee == null)
            {
                employeeResponse.Success = false;
                employeeResponse.NotFound = true;
                return employeeResponse;
            }
            var res = _context.Employees.Remove(employee);
            _context.SaveChanges();
            employeeResponse.Success = true;
            return employeeResponse;
        }

        public async Task<EmployeeResponseDetails> getAllEmployee()
        {
            var employeeResponse = new EmployeeResponseDetails();
            try
            {
                var listEmployees = await _context.Employees.OrderByDescending(e => e.Id).ToListAsync();
                employeeResponse.Success = true;
                employeeResponse.ListEmpoyees = listEmployees;
                return employeeResponse;
            }
            catch (Exception ex)
            {
                employeeResponse.Exception = ex.Message;
                employeeResponse.Success = false;
                return employeeResponse;
            }
        }

        public async Task<EmployeeResponseDetails> getSingleEmployee(int employeeId)
        {
            var employeeResponse = new EmployeeResponseDetails();
            try
            {
                if (employeeId == null)
                {
                    employeeResponse.Success = false;
                    return employeeResponse;
                }
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
                if (employee == null)
                {
                    employeeResponse.Success = false;
                    employeeResponse.NotFound = true;
                    return employeeResponse;
                }
                employeeResponse.Success = true;
                employeeResponse.SingleEmployee = employee;
                return employeeResponse;
            }
            catch (Exception ex)
            {
                employeeResponse.Exception = ex.Message;
                employeeResponse.Success = false;
                return employeeResponse;
            }
        }

        public async Task<EmployeeResponseDetails> updateEmployee(int employeeId, Employee _employee)
        {
            var employeeResponse = new EmployeeResponseDetails();
            try
            {
                if (employeeId == null)
                {
                    employeeResponse.Success = false;
                    return employeeResponse;
                }
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
                if (employee == null)
                {
                    employeeResponse.Success = false;
                    employeeResponse.NotFound = true;
                    return employeeResponse;
                }
                employee.FirstName = _employee.FirstName;
                employee.LastName = _employee.LastName;
                employee.Birthdate = _employee.Birthdate;
                employee.Salary = _employee.Salary;
                employee.Gender = _employee.Gender;
                var res = await _context.SaveChangesAsync();
                employeeResponse.Success = true;
                employeeResponse.SingleEmployee = employee;
                return employeeResponse;
            }
            catch (Exception ex)
            {
                employeeResponse.Exception = ex.Message;
                employeeResponse.Success = false;
                return employeeResponse;
            }
        }
    }
}
