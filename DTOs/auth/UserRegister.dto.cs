public class UserRegister
{
    public string fullName { get; set; }
    public string email { get; set; }
    public string password { get; set; }

    public UserRegister()
    {
        fullName = string.Empty;
        email = string.Empty;
        password = string.Empty;
    }
}