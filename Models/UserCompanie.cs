public class UserCompanie {

    public int Id { get; set; }
    public int IdCompanie { get; set; }
    public int IdUser { get; set; }
    public int IdRole { get; set; }
    
    public UserCompanie()
    {
        IdCompanie = 0;
        IdUser = 0;
        IdRole = 0;
    }

}