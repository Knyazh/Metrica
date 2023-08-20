using Metrica1.Database.Models;
using Metrica1.ViewModels.Employee;

namespace Metrica1.ViewModels.Employees
{
    public class EmployeeListViewModel : EmployeeBaseViewModels
    {
        public string UserCode { get; set; }
      
        public string ImageURL { get; set; }
        public Agency Agency { get; set; }
        public bool IsDeleted { get; set; }
    }
}
