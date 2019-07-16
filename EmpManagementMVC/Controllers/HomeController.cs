using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmpManagementMVC.ViewModels;
using EmployeeManagement.Data.Core;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EmpManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        public HomeController(IEmployeeRepository repository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = repository;
            this.hostingEnvironment = hostingEnvironment;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel employee)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (employee.Photo != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + employee.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    employee.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }


                var emp = new Employee()
                {
                    Email = employee.Email,
                    Department = employee.Department.ToString(),
                    Name = employee.Name,
                    PhotoPath = uniqueFileName
                };
                var res = _employeeRepository.Add(emp);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        public IActionResult PutData(string inputParam)
        {
            var res = _employeeRepository.GetAllEmployees();
            return View("Index", res);
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

        public IActionResult Edit(int id)
        {
            var emp = _employeeRepository.GetEmployee(id);
            var employee = new EmployeeViewModel()
            {
                Department = (Dept)Enum.Parse(typeof(Dept), emp.Department),
                Email = emp.Email,
                Name = emp.Name,
                ExistingPhotoPath = emp.PhotoPath
            };
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            string uniqueFileName = null;
            if (employeeViewModel.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                // To make sure the file name is unique we are appending a new
                // GUID value and and an underscore to the file name
                uniqueFileName = Guid.NewGuid().ToString() + "_" + employeeViewModel.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                employeeViewModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            
            var emp = new Employee
            {
                Department = employeeViewModel.Department.ToString(),
                Name = employeeViewModel.Name,
                Email = employeeViewModel.Email,
                Id = employeeViewModel.Id,
                PhotoPath = employeeViewModel.Photo != null ? uniqueFileName  : employeeViewModel.ExistingPhotoPath
            };
            _employeeRepository.Update(emp);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var emp = _employeeRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
