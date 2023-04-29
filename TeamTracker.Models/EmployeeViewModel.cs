namespace TeamTracker.Models;

public class EmployeeViewModel
{
    public int EmployeeID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public int DepartmentID { get; set; }
    public string DepartmentName { get; set; }
    public int ProgrammingLanguageID { get; set; }
    public string ProgrammingLanguageName { get; set; }
}