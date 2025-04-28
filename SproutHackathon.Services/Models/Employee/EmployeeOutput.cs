namespace SproutHackathon.Services.Models
{
    public class EmployeeOutput
    {
        public required BasicInformation BasicInformation { get; set; }
        public GovernmentInformation? GovernmentInformation { get; set; }
        public ContactInformation? ContactInformation { get; set; }
        public WorkInformation? WorkInformation { get; set; }
        public SalaryHistory? SalaryHistory { get; set; }
        public Advance? Advance { get; set; }
        public Dependent? Dependent { get; set; }
        public List<EducationalBackground>? EducationalBackground { get; set; }
    }
    public class BasicInformation
    {
        public int SystemId { get; set; }
        public required string EmployeeId { get; set; }
        public required string FirstName { get; set; }
        public required string MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string Gender { get; set; }
        public required string CivilStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int SecurityGroupId { get; set; }
    }

    public class GovernmentInformation
    {
        public required string Sss { get; set; }
        public required string Tin { get; set; }
        public required string PhilHealth { get; set; }
        public required string PagIbig { get; set; }
        public required string PrcLicense { get; set; }
        public required string Passport { get; set; }
    }

    public class ContactInformation
    {
        public required string PrimaryContactNumber { get; set; }
        public required List<Email> Emails { get; set; }
        public required List<PhoneNumber> PhoneNumbers { get; set; }
    }

    public class Email
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public required string EmailAddress { get; set; }
        public bool IsDefault { get; set; }
    }

    public class PhoneNumber
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public required string PhoneTitle { get; set; }
        public required string Number { get; set; }
        public required string ContactPerson { get; set; }
    }

    public class WorkInformation
    {
        public int CompanyId { get; set; }
        public required string Title { get; set; }
        public required string EmployeeType { get; set; }
        public required string Department { get; set; }
    }

    public class SalaryHistory
    {
        public required List<BankAccount> BankAccounts { get; set; }
    }

    public class BankAccount
    {
        public required string Bank { get; set; }
        public required string BankAccountNumber { get; set; }
    }

    public class Advance
    {
        public required List<EmployeeAdvance> EmployeeAdvances { get; set; }
    }

    public class EmployeeAdvance
    {
        public int Id { get; set; }
        public float TotalAmount { get; set; }
    }

    public class Dependent
    {
        public required List<EmployeeDependent> EmployeeDependents { get; set; }
    }

    public class EmployeeDependent
    {
        public required string FirstName { get; set; }
        public required string Relationship { get; set; }
    }

    public class EducationalBackground
    {
        public long Id { get; set; }
        public required string School { get; set; }
        public required string Degree { get; set; }
    }
}