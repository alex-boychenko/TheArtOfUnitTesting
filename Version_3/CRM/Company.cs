﻿namespace TheArtOfUnitTesting;

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
        NumberOfEmployees += delta;
    }

    public bool IsEmailCorporate(string email)
    {
        string emailDomain = email.Split('@')[1];

        return emailDomain == DomainName;
    }
}
