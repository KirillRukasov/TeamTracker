using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TeamTracker.Models;

namespace TeamTracker.Data.Repositories;

public class ProgrammingLanguageRepository : IProgrammingLanguageRepository
{
    private readonly TeamTrackerDbContext _dbContext;

    public ProgrammingLanguageRepository(TeamTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<ProgrammingLanguage> GetProgrammingLanguages()
    {
        return _dbContext.ProgrammingLanguages.FromSqlRaw("EXECUTE GetProgrammingLanguages").ToList();
    }

    public ProgrammingLanguage GetProgrammingLanguageById(int programmingLanguageId)
    {
        return _dbContext.ProgrammingLanguages.FromSqlRaw("EXECUTE GetProgrammingLanguageByID @ProgrammingLanguageID", 
            new SqlParameter("@ProgrammingLanguageID", programmingLanguageId)).FirstOrDefault();
    }

    public void AddProgrammingLanguage(ProgrammingLanguage programmingLanguage)
    {
        _dbContext.Database.ExecuteSqlRaw("EXECUTE AddProgrammingLanguage @Name", new SqlParameter("@Name", programmingLanguage.Name));
    }

    public void UpdateProgrammingLanguage(ProgrammingLanguage programmingLanguage)
    {
        _dbContext.Database.ExecuteSqlRaw("EXECUTE UpdateProgrammingLanguage @ProgrammingLanguageID, @Name", 
            new SqlParameter("@ProgrammingLanguageID", programmingLanguage.ProgrammingLanguageID), 
            new SqlParameter("@Name", programmingLanguage.Name));
    }

    public void DeleteProgrammingLanguage(int programmingLanguageId)
    {
        _dbContext.Database.ExecuteSqlRaw("EXECUTE DeleteProgrammingLanguageByID @ProgrammingLanguageID", 
            new SqlParameter("@ProgrammingLanguageID", programmingLanguageId));
    }
}