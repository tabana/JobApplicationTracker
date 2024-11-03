namespace JobApplicationTracker.ViewModel;

public class JobApplication
{
    public Guid Id { get; set; }
    public Guid ApplicantId { get; set; }
    public Guid EmployerId { get; set; }
    public Guid SourceId { get; set; }
    public Guid RecruiterId { get; set; }
    public Guid StatusId { get; set; }
    public string? JobIdentifier { get; set; }
    public string? ResumePath { get; set; }
    public string? Notes { get; set; }

    public Employer? Employer { get; set; }
    public Source? Source { get; set; }
    public Recruiter? Recruiter { get; set; }
    public Status? Status { get; set; }
}



