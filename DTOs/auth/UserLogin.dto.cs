public class UserLogin
{
    public string email { get; set; }
    public string password { get; set; }

    public UserLogin()
    {
        email = string.Empty;
        password = string.Empty;
    }
}