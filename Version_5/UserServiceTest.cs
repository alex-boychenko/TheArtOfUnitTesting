using FluentAssertions;
using Xunit;

namespace TheArtOfUnitTesting;

public class UserServiceTest
{
    [Fact]
    public void Changing_email_from_non_corporate_to_corporate()
    {
        //Arrange
        var company = new Company("mycorp.com", 1);
        var sut = new User(1, "user@gmail.com", UserType.Customer, true);

        var newEmail = "new@mycorp.com";

        //Act
        sut.ChangeEmail(newEmail, company);

        //Assert
        Assert.Equal(2, company.NumberOfEmployees);
        Assert.Equal(newEmail, sut.Email);
        Assert.Equal(UserType.Employee, sut.Type);

        //Для достижения полного покрытия понадобятся еще три таких теста:
        //public void Changing_email_from_corporate_to_non_corporate()
        //public void Changing_email_without_changing_user_type()
        //public void Changing_email_to_the_same_one()
    }

    [InlineData("mycorp.com", "email@mycorp.com", true)]
    [InlineData("mycorp.com", "email@gmail.com", false)]
    [Theory]
    public void Differentiates_a_corporate_email_from_non_corporate(
        string domain, string email, bool expectedResult)
    {
        //Arrange
        var sut = new Company(domain, 0);

        //Act
        bool isEmailCorporate = sut.IsEmailCorporate(email);

        //Assert
        Assert.Equal(expectedResult, isEmailCorporate);
    }

    [Fact]
    public void Changing_email_from_corporate_to_non_corporate()
    {
        //Arrange
        var company = new Company("mycorp.com", 1);
        var sut = new User(1, "user@mycorp.com", UserType.Employee, true);

        var newEmail = "new@gmail.com";

        //Act
        sut.ChangeEmail(newEmail, company);

        //Assert
        company.NumberOfEmployees.Should().Be(0);
        sut.Email.Should().Be(newEmail);
        sut.Type.Should().Be(UserType.Customer);
        sut.EmailChangedEvents.Should().ContainEquivalentOf(new EmailChangedEvent(1, newEmail));
    }
}