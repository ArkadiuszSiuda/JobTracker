namespace JobTracker.Entities;

public class JobOffer
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Position { get; set; }
    public SalaryRange? SalaryRange { get; set; }
    public string? Note { get; set; }
    public string Link { get; set; }
    public DateTime SubmissionDate { get; set; }
    public Statuses Status { get; set; }
}
