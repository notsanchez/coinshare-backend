using Microsoft.EntityFrameworkCore;
using MySqlConnector;

public class CompanieService
{
    private readonly AppDbContext _dbContext;

    public CompanieService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Companie> GetMyCompanie(string userId)
    {

        string sql = "SELECT C.Id, C.Name FROM Companies C INNER JOIN UsersCompanies UC ON C.Id = UC.IdCompanie WHERE UC.IdUser = @UserId";

        object[] parameters = new object[]
        {
            new MySqlParameter("@UserId", userId) { MySqlDbType = MySqlDbType.VarChar, Size = 255 },
        };

        var companie = await _dbContext.Companies.FromSqlRaw(sql, parameters).FirstOrDefaultAsync();

        return companie;
    }

    
}
