using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Core
{
    public interface IEmployeeRepository
    {
        Employee Add(Employee employee);
        Employee Delete(int Id);
        IEnumerable<Employee> GetAllEmployee();
        Employee Update(Employee employeeChanges);
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();
    }
}
