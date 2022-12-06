namespace TheArtOfUnitTesting;

public class Company
{
    public int NumberOfEmployees { get; set; }
    public string CompanyDomainName { get; set; }
    public Company(int numberOfEmployees, string companyDomainName)
    {
        NumberOfEmployees = numberOfEmployees;
        CompanyDomainName = companyDomainName;
    }
}
