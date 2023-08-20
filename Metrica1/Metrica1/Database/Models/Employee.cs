using System.ComponentModel.DataAnnotations;

namespace Metrica1.Database.Models;

public class Employee
{

    public Employee() {}
    [Key]
    public string UserCode { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FatherName { get; set; }
    public string PIN { get; set; }
    public string Email { get; set; }
    public string ImageURL { get; set; }
    public bool IsDeleted { get; set; }
    public int AgencyId { get; set; }
    public Agency Agency { get; set; }
}
