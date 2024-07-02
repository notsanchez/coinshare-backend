public class User {

    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User()
    {
        FullName = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
    }

}