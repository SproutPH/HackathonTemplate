namespace SproutHackathon.Business.DTOs
{
  public class CompanyDto
  {
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string PerfProUrl { get; set; }
    public PayrollSyncDetailsDto PayrollSyncDetails { get; set; }
    public string PayrollPieDatabase { get; set; }
  }

  public class PayrollSyncDetailsDto
  {
    public bool IsConnected { get; set; }
    public string CompanyCode { get; set; }
  }
}