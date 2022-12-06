namespace TheArtOfUnitTesting;

public interface IMessageBus
{
    public void SendEmailChangedMessage(int userId, string newEmail);
}

internal class MessageBus : IMessageBus
{
    public void SendEmailChangedMessage(int userId, string newEmail)
    {
        Console.WriteLine("Email has been sent");
    }
}
