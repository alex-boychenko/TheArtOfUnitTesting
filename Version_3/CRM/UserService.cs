namespace TheArtOfUnitTesting;

public class UserService
{
    private readonly IDatabase _database;
    private readonly IMessageBus _messageBus;

    public UserService(IDatabase database, IMessageBus messageBus)
    {
        _database = database;
        _messageBus = messageBus;
    }

    public void ChangeEmail(int userId, string newEmail)
    {
        var user = _database.GetUserById(userId);
        var company = _database.GetCompany();

        user.ChangeEmail(newEmail, company);

        _database.SaveCompany(company);
        _database.SaveUser(user);
        _messageBus.SendEmailChangedMessage(userId, newEmail);
    }
}

