public class Feedback {

    public int Id { get; set; }
    public int IdUserGived { get; set; }
    public int IdUserReceived { get; set; }
    public string Description { get; set; }
    public int Rating { get; set; }

    public Feedback()
    {
        IdUserGived = 0;
        IdUserReceived = 0;
        Description = string.Empty;
        Rating = 0;
    }

}