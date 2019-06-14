using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmpManagementMVC.Models;
using EmpManagementMVC.ViewModels;

namespace EmpManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository repository)
        {
            _employeeRepository = repository;
        }
        public IActionResult Index()
        {
            var res = _employeeRepository.GetAllEmployees();
            return View(res);
        }

        public IActionResult Details(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            var res = new HomeDetailsViewModel() { Employee = employee, PageTitle = "Employee Details" };
            return View(res);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
