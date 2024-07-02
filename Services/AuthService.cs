using Microsoft.EntityFrameworkCore;
using MySqlConnector;

public class AuthService
{
    private readonly AppDbContext _dbContext;

    public AuthService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> Login(string email, string password)
    {

        string sql = "SELECT * FROM Users U WHERE U.Email = @Email AND U.Password = @Password";

        object[] parameters = new object[]
        {
            new MySqlParameter("@Email", email) { MySqlDbType = MySqlDbType.VarChar, Size = 255 },
            new MySqlParameter("@Password", password) { MySqlDbType = MySqlDbType.VarChar, Size = 255 },
        };

        var user = await _dbContext.Users.FromSqlRaw(sql, parameters).FirstOrDefaultAsync();

        return user;
    }

    public async Task<User> Register(string fullName, string email, string password)
    {

        string sql = "INSERT INTO Users (FullName, Email, Password) VALUES (@FullName, @Email, @Password);";

        object[] parameters = new object[]
        {
            new MySqlParameter("@FullName", fullName) { MySqlDbType = MySqlDbType.VarChar, Size = 255 },
            new MySqlParameter("@Email", email) { MySqlDbType = MySqlDbType.VarChar, Size = 255 },
            new MySqlParameter("@Password", password) { MySqlDbType = MySqlDbType.VarChar, Size = 255 },
        };

        var user = await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);

        var newUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        return newUser;
    }
}
