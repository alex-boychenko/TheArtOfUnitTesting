using Moq;
using Xunit;

namespace TheArtOfUnitTesting;

public class UserServiceTest
{
    [Fact]
    public void Customer_becomes_employee_when_new_email_belongs_to_company_domain()
    {
        //Arrange
        var database = new Mock<IDatabase>();

        var user = new User(1, "alex@yandex.ru", UserType.Customer);
        database.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(user);

        var company = new Company(10, "bimeister.com");
        database.Setup(x => x.GetCompany()).Returns(company);

        var messageBus = new Mock<IMessageBus>();
        var sut = new UserService(database.Object, messageBus.Object);

        var newEmail = "alex@bimeister.com";

        //Act
        sut.ChangeEmail(1, newEmail);

        //Assert
        var expectedNumberOfEmployees = 11;
        var expectedUserType = UserType.Employee;

        Assert.Equal(expectedNumberOfEmployees, company.NumberOfEmployees);
        Assert.Equal(expectedUserType, user.Type);
        Assert.Equal(newEmail, user.Email);
        messageBus.Verify(messageBus => messageBus.SendEmailChangedMessage(user.UserId, user.Email), Times.Once());
    }
}