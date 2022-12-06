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
        if (Email == newEmail) return;

        string emailDomain = newEmail.Split('@')[1];

        bool isEmailCorporate = emailDomain == company.CompanyDomainName;
        UserType newType = isEmailCorporate ? UserType.Employee : UserType.Customer;

        if (Type != newType)
        {
            int delta = newType == UserType.Employee ? 1 : -1;
            int newNumber = company.NumberOfEmployees + delta;
            company.NumberOfEmployees = newNumber;
        }

        Email = newEmail;
        Type = newType;
    }
}
