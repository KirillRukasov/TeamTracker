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
    public int Age { get; set; }

    [Required]
    [MaxLength(1)]
    public string Gender { get; set; }

    [ForeignKey("Department")]
    public int DepartmentID { get; set; }
    public virtual Department Department { get; set; }

    [ForeignKey("ProgrammingLanguage")]
    public int ProgrammingLanguageID { get; set; }
    public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }
}