namespace TheArtOfUnitTesting;

public interface IDatabase
{
    public Company GetCompany();
    public User GetUserById(int userId);
    public void SaveCompany(Company company);
    public void SaveUser(User user);
}
