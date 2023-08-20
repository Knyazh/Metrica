using Metrica1.Database.Models;
using Metrica1.ViewModels.Employee;

namespace Metrica1.ViewModels.Employees
{
    public class EmployeeListViewModel : EmployeeBaseViewModels
    {
        public string UserCode { get; set; }
      
        public string PIN { get; set; }
        public string Email { get; set; }
        public string ImageURL { get; set; }
        public int DepartmentId { get; set; }
        //public Department Department { get; set; }
        public bool IsDeleted { get; set; }
    }
}
