using TeamTracker.Models;

namespace TeamTracker.Data.Repositories;

public interface IProgrammingLanguageRepository
{
    IEnumerable<ProgrammingLanguage> GetProgrammingLanguages();
    ProgrammingLanguage GetProgrammingLanguageById(int programmingLanguageId);
    void AddProgrammingLanguage(ProgrammingLanguage programmingLanguage);
    void UpdateProgrammingLanguage(ProgrammingLanguage programmingLanguage);
    void DeleteProgrammingLanguage(int programmingLanguageId);
}