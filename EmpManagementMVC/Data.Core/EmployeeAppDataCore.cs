using EmpManagementMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagementMVC.Data.Core
{
    public class EmployeeAppDataCore : DbContext
    {
        public EmployeeAppDataCore(DbContextOptions<EmployeeAppDataCore> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
