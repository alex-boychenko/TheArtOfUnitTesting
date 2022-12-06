namespace TheArtOfUnitTesting;

public enum UserType
{
    Customer = 1,
    Employee = 2
}

public class User
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public UserType Type { get; set; }
    public User(int userId, string email, UserType type)
    {
        UserId = userId;
        Email = email;
        Type = type;
    }
}
