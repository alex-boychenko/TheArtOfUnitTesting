namespace TheArtOfUnitTesting;

//бизнес-сценарий: изменение адреса электронной почты пользователя. В этой операции задействованы три бизнес-правила: 
//
//* если адрес электронной почты(имейл) принадлежит домену компании, то пользователь помечается как работник.В противном случае он помечается как клиент; 
//* система должна отслеживать количество работников.Если тип пользователя меняется с работника на клиента (или наоборот), то это число тоже должно изменяться;
//* при изменении имейла система должна оповестить об этом внешние системы, отправив сообщение по шине сообщений

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

        if (!user.IsEmailConfirmed)
            throw new PreconditionException("Can't change a confirmed email");

        user.ChangeEmail(newEmail, company);

        _database.SaveCompany(company);
        _database.SaveUser(user);

        // В текущей реализации в функциональности уведомления присутствует дефект:
        // она отправляет сообщения даже в том случае, если адрес электронной почты не изменился
        _messageBus.SendEmailChangedMessage(userId, newEmail);

    }
}

