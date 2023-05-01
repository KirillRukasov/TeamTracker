namespace TeamTracker.Models;

public class EmployeeEditViewModel
{
    public Employee Employee { get; set; }
    public IEnumerable<Department> Departments { get; set; }
    public IEnumerable<ProgrammingLanguage> ProgrammingLanguages { get; set; }
}