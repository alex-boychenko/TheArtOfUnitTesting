namespace TheArtOfUnitTesting;

public class EmailChangedEvent
{
    public int UserId { get; set; }
    public string NewEmail { get; set; }

    public EmailChangedEvent(int userId, string newEmail)
    {
        UserId = userId;
        NewEmail = newEmail;
    }
}