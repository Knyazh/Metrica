using System.ComponentModel.DataAnnotations;

namespace Metrica1.Database.Models
{
    public class Agency
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
