namespace SproutHackathon.Services.Models
{
    public class Employee
    {
        public required BasicInformation basicInformation { get; set; }
        public GovernmentInformation? governmentInformation { get; set; }
        public ContactInformation? contactInformation { get; set; }
        public WorkInformation? workInformation { get; set; }
        public SalaryHistory? salaryHistory { get; set; }
        public Advance? advance { get; set; }
        public Dependent? dependent { get; set; }
        public List<EducationalBackground>? educationalBackground { get; set; }

        public class BasicInformation
        {
            public int systemId { get; set; }
            public required string employeeId { get; set; }
            public required string firstName { get; set; }
            public required string middleName { get; set; }
            public required string lastName { get; set; }
            public required string gender { get; set; }
            public required string civilStatus { get; set; }
            public DateTime dateOfBirth { get; set; }
            public int securityGroupId { get; set; }
        }

        public class GovernmentInformation
        {
            public required string sss { get; set; }
            public required string tin { get; set; }
            public required string philHealth { get; set; }
            public required string pagIbig { get; set; }
            public required string prcLicense { get; set; }
            public required string passport { get; set; }
        }

        public class ContactInformation
        {
            public required string primaryContactNumber { get; set; }
            public required List<Email> emails { get; set; }
            public required List<PhoneNumber> phoneNumbers { get; set; }
        }

        public class Email
        {
            public int id { get; set; }
            public int empId { get; set; }
            public required string email { get; set; }
            public bool isDefault { get; set; }
        }

        public class PhoneNumber
        {
            public int id { get; set; }
            public int empId { get; set; }
            public required string phoneTitle { get; set; }
            public required string phoneNumber { get; set; }
            public required string phoneContact { get; set; }
        }

        public class WorkInformation
        {
            public int companyId { get; set; }
            public required string title { get; set; }
            public required string employeeType { get; set; }
            public required string department { get; set; }
        }

        public class SalaryHistory
        {
            public required List<BankAccount> bankAccounts { get; set; }
        }

        public class BankAccount
        {
            public required string bank { get; set; }
            public required string bankAccountNumber { get; set; }
        }

        public class Advance
        {
            public required List<EmployeeAdvance> employeeAdvances { get; set; }
        }

        public class EmployeeAdvance
        {
            public int id { get; set; }
            public float totalAmount { get; set; }
        }

        public class Dependent
        {
            public required List<EmployeeDependent> employeeDependent { get; set; }
        }

        public class EmployeeDependent
        {
            public required string firstName { get; set; }
            public required string relationship { get; set; }
        }

        public class EducationalBackground
        {
            public long id { get; set; }
            public required string school { get; set; }
            public required string degree { get; set; }
        }
    }
}
