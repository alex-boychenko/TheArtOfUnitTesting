namespace TheArtOfUnitTesting;

public enum UserType
{
    Customer = 1,
    Employee = 2
}

public class User
{
    public int UserId { get; private set; }
    public string Email { get; private set; }
    public UserType Type { get; private set; }

    public User(int userId, string email, UserType type)
    {
        UserId = userId;
        Email = email;
        Type = type;
    }

    public void ChangeEmail(string newEmail, Company company)
    {
        if (Email == newEmail)
            return;

        UserType newType = company.IsEmailCorporate(newEmail) ? UserType.Employee : UserType.Customer;

        if (Type != newType)
        {
            int delta = newType == UserType.Employee ? 1 : -1;
            company.ChangeNumberOfEmployees(delta);
        }

        Email = newEmail;
        Type = newType;
    }
}
