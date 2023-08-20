using Metrica1.Database.Models;
using Metrica1.ViewModels.Employee;

namespace Metrica1.ViewModels.Employees
{
    public class EmployeeAddViewModel : EmployeeBaseViewModels
    {
        
     
        public string PIN { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }
        public int DepartmentId { get; set; }
        //public List<Department> Departments { get; set; }


    }
}
