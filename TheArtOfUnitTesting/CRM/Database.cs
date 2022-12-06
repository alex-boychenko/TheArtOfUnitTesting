namespace TheArtOfUnitTesting;

public interface IDatabase
{
    public Company GetCompany();
    public User GetUserById(int userId);
    public void SaveCompany(Company company);
    public void SaveUser(User user);
}

internal class Database : IDatabase
{
    public Company GetCompany()
    {
        return new Company(10, "some.domain");
    }

    public User GetUserById(int userId)
    {
        return new User(userId, "some.email", UserType.Employee);
    }

    public void SaveCompany(Company company)
    {
        Console.WriteLine("Company vas saved");
    }

    public void SaveUser(User user)
    {
        Console.WriteLine("User vas saved");
    }
}
