using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamTracker.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeID { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Surname { get; set; }

    [Required]
    [Range(1, 119, ErrorMessage = "Department ID must be between 1 and 119.")]
    public int Age { get; set; }

    [Required]
    [MaxLength(1)]
    [RegularExpression("^(M|F)$", ErrorMessage = "Gender must be either 'M' or 'F'")]
    public string Gender { get; set; }

    [ForeignKey("Department")]
    public int DepartmentID { get; set; }

    [ForeignKey("ProgrammingLanguage")]
    public int ProgrammingLanguageID { get; set; }
}