using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamTracker.Models;

public class ProgrammingLanguage
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProgrammingLanguageID { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}