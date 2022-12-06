namespace TheArtOfUnitTesting;

public class Company
{
    public string DomainName { get; private set; }
    public int NumberOfEmployees { get; private set; }

    public Company(string domainName, int numberOfEmployees)
    {
        DomainName = domainName;
        NumberOfEmployees = numberOfEmployees;
    }

    public void ChangeNumberOfEmployees(int delta)
    {
        // Нужно ли тестировать такие предусловия?

        // Рекомендуется тестировать все предусловия, которые относятся к предметной области (домену) приложения.
        // Требование неотрицательности количества работников является таким предусловием. Оно является частью инвариантов класса Company
        // Но не тратьте время на тестирование предусловий, не относящихся к предметной области.
        Precondition.Requires(NumberOfEmployees + delta >= 0);

        NumberOfEmployees += delta;
    }

    public bool IsEmailCorporate(string email)
    {
        string emailDomain = email.Split('@')[1];

        return emailDomain == DomainName;
    }
}
