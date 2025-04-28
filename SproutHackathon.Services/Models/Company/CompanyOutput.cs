namespace SproutHackathon.Services.Models.Company
{
    public class CompanyOuput
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PerfProUrl { get; set; }
        public PayrollSyncDetailsOutput PayrollSyncDetails { get; set; }
        public string PayrollPieDatabase { get; set; }
    }

    public class PayrollSyncDetailsOutput
    {
        public bool IsConnected { get; set; }
        public string CompanyCode { get; set; }
    }
}