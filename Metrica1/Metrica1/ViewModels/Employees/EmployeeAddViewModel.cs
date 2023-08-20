using Metrica1.Database.Models;
using Metrica1.ViewModels.Employee;

namespace Metrica1.ViewModels.Employees
{
    public class EmployeeAddViewModel : EmployeeBaseViewModels
    {
        
        public IFormFile Image { get; set; }
        public List<Agency> Agencies { get; set; }

    }
}
