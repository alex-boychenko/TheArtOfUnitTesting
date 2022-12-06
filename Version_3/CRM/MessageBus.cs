namespace TheArtOfUnitTesting;

public interface IMessageBus
{
    public void SendEmailChangedMessage(int userId, string newEmail);
}
