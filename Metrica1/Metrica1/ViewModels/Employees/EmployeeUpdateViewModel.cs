using Metrica1.Database.Models;
using Metrica1.ViewModels.Employee;
using System.ComponentModel.DataAnnotations;

namespace Metrica1.ViewModels.Employees
{
    public class EmployeeUpdateViewModel :EmployeeBaseViewModels
    {
        [Key]
        public string UserCode { get; set; }
     
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }

        public List<Agency> Agencies { get; set; }


    }
}
