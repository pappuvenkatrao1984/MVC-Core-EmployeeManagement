using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Core
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public EmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
               new Employee(){ Id = 1, Department = "IT", Email = "it@sysven.com", Name = "IT Department" },
                new Employee(){ Id = 2, Department = "HR", Email = "hr@sysven.com", Name = "HR Department" },
                 new Employee(){ Id = 3, Department = "Admin", Email = "admin@sysven.com", Name = "Admin Department" },
                  new Employee(){ Id = 4, Department = "Management", Email = "management@sysven.com", Name = "Management Department" }
            };

        }

        public Employee Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(r => r.Id == id);
        }

        public Employee Update(Employee employeeChanges)
        {
            throw new NotImplementedException();
        }
    }
}
