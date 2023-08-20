using System.ComponentModel.DataAnnotations;

namespace Metrica1.Database.Models;

public class Employee
{

    public Employee() {}

    [Key]
    [RegularExpression("^E\\d{5}$", ErrorMessage = "userCode must start with 'E' followed by 5 digits.")]
    public string UserCode { get; set; }
    [Required]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be 3 and 20 characters.")]
    public string Name { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Surname must be 3 and 20 characters.")]
    public string Surname { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Father Name must be  3 and 20 characters.")]
    public string FatherName { get; set; }
    [Required]
    [PinValidation(ErrorMessage ="Pin must be between 7 digiths and letter")]
    public string Pin { get; set; }
    [Required]
    [RegularExpression(".*@.*", ErrorMessage = "Email must contain the @ character.")]
    public string Email { get; set; }
    public string ImageURL { get; set; }
    public bool IsDeleted { get; set; }
    public int AgencyId { get; set; }
    public Agency Agency { get; set; }
}
