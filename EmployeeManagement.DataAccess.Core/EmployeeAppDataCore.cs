using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Core
{
    public class EmployeeAppDataCore : DbContext
    {
        public EmployeeAppDataCore(DbContextOptions<EmployeeAppDataCore> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
