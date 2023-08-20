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
                ImageURL = e.ImageURL,
                IsDeleted = e.IsDeleted
            })
            .OrderBy(x => x.IsDeleted)
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

    }
}
