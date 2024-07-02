using Microsoft.EntityFrameworkCore;
using MySqlConnector;

public class UserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateUserAsync(User newUser)
    {

        string sql = "INSERT INTO Users (FullName, Email, Password) VALUES (@FullName, @Email, @Password);";

        object[] parameters = new object[]
        {
            new MySqlParameter("@FullName", newUser.FullName) { MySqlDbType = MySqlDbType.VarChar, Size = 100 },
            new MySqlParameter("@Email", newUser.Email) { MySqlDbType = MySqlDbType.VarChar, Size = 100 },
            new MySqlParameter("@Password", newUser.Password) { MySqlDbType = MySqlDbType.VarChar, Size = 100 }
        };

        int rowsAffected = await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);

        return rowsAffected;
    }
}
