using Metrica.Database;
using Metrica1.Database.Models;
using Metrica1.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.IO;

namespace Metrica1.Controllers.Admin
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            _matricaDbContext = new MatricaDbContext();
        }

        private readonly MatricaDbContext _matricaDbContext;
        private readonly string uploadsPath = "C:\\Users\\asus\\Desktop\\Metrica\\Metrica1\\Metrica1\\wwwroot\\uploads\\";
      
        //string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension("file")}";
       

        public IActionResult Index()
        {

            var productViewModels = _matricaDbContext.Employees
            .Select(e => new EmployeeListViewModel
            {
                Name = e.Name,
                Surname = e.Surname,
                FatherName = e.FatherName,
                Email = e.Email,
                UserCode = e.UserCode,
                PIN = e.Pin,
                Agency = e.Agency,
                AgencyId = e.AgencyId,
                ImageURL = e.ImageUrl,
                IsDeleted = e.IsDeleted
            })
            .OrderBy(x => x.IsDeleted)
            .ToList();

            return View(productViewModels);
        }


        public IActionResult DeleteIndex()
        {

            var productViewModels = _matricaDbContext.Employees
            .Select(e => new EmployeeListViewModel
            {
                Name = e.Name,
                Surname = e.Surname,
                FatherName = e.FatherName,
                Email = e.Email,
                UserCode = e.UserCode,
                PIN = e.Pin,
                Agency = e.Agency,
                AgencyId = e.AgencyId,
                ImageURL = e.ImageUrl,
                IsDeleted = e.IsDeleted
            })
            .Where(x => x.IsDeleted)
            .ToList();

            return View(productViewModels);
        }

        public IActionResult Add()
        {
            EmployeeAddViewModel employeeAddViewModel = new ()
            {
                Agencies = _matricaDbContext.Agencies.ToList()
            };

            return View(employeeAddViewModel);
        }

        [HttpPost]
        public IActionResult Add(EmployeeAddViewModel employeeAddViewModel)
        {
            if (!ModelState.IsValid) { return View(employeeAddViewModel); }

            Employee employee = new()
            {
                Email = employeeAddViewModel.Email,
                AgencyId = employeeAddViewModel.AgencyId,
                FatherName = employeeAddViewModel.FatherName,
                Name = employeeAddViewModel.Name,
                Pin = employeeAddViewModel.PIN,
                Surname = employeeAddViewModel.Surname,
                IsDeleted = false

            };

            _matricaDbContext.Employees.Add(employee);
            _matricaDbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Update(string userCode)
        {


            var updatedEmployee = _matricaDbContext.Employees.FirstOrDefault(x => x.UserCode == userCode);
            if (updatedEmployee is null)  return NotFound();

            EmployeeUpdateViewModel employeeUpdateViewModel = new()
            {
                Name = updatedEmployee.Name,
                Surname = updatedEmployee.Surname,
                FatherName = updatedEmployee.FatherName,
                Email = updatedEmployee.Email,
                AgencyId = updatedEmployee.AgencyId,
                ImageUrl = updatedEmployee.ImageUrl,
                PIN = updatedEmployee.Pin,
                Agencies = _matricaDbContext.Agencies.ToList()

            };

            return View(employeeUpdateViewModel);
        }

        [HttpPost]
        public IActionResult Update(EmployeeUpdateViewModel PreviousEmployeeUpdateViewModel)
        {
            PreviousEmployeeUpdateViewModel.Agencies = _matricaDbContext.Agencies.ToList();
            if (!ModelState.IsValid) return View(PreviousEmployeeUpdateViewModel);

            var updatedEmployee = _matricaDbContext.Employees.FirstOrDefault(x => x.UserCode == PreviousEmployeeUpdateViewModel.UserCode);
            if (updatedEmployee ==null)
            {
                ModelState.AddModelError("Name", "Product not found");
                return View("~/Views/Home/Update.cshtml");
            }
            string exImageUrl = updatedEmployee.ImageUrl;


            updatedEmployee.Surname = PreviousEmployeeUpdateViewModel.Surname;
            updatedEmployee.FatherName = PreviousEmployeeUpdateViewModel.FatherName;
            updatedEmployee.Name = PreviousEmployeeUpdateViewModel.Name;
            updatedEmployee.Email = PreviousEmployeeUpdateViewModel.Email;
            updatedEmployee.AgencyId = PreviousEmployeeUpdateViewModel.AgencyId;
            updatedEmployee.Pin = updatedEmployee.Pin;
            updatedEmployee.UserCode = PreviousEmployeeUpdateViewModel.UserCode;


            _matricaDbContext.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(string userCode)
        {
            var deletedEmployee = _matricaDbContext.Employees.FirstOrDefault(u => u.UserCode == userCode);
            if (deletedEmployee == null)  return NotFound(); 

            deletedEmployee.IsDeleted = true;
            _matricaDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
