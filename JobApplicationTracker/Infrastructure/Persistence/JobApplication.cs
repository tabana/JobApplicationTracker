using SQLite;
using SQLiteNetExtensions.Attributes;

namespace JobApplicationTracker.Infrastructure.Persistence
{
    [Table("JobApplication")]
    public class JobApplication
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        [ForeignKey(typeof(Applicant))]
        public Guid ApplicantId { get; set; }
        [ForeignKey(typeof(Employer))]
        public Guid EmployerId { get; set; }
        [ForeignKey(typeof(Source))]
        public Guid SourceId { get; set; }
        [ForeignKey(typeof(Recruiter))]
        public Guid RecruiterId { get; set; }
        public Guid StatusId { get; set; }
        public string? JobIdentifier { get; set; }
        public string? ResumePath { get; set; }
        public string? Notes {  get; set; }

        [ManyToOne]
        public Applicant? Applicant { get; set; }
        [OneToOne]
        public Employer? Employer { get; set; }
        [OneToOne]
        public Source? Source { get; set; }
        [OneToOne]
        public Recruiter? Recruiter { get; set; }
        public Status? Status { get; set; }
    }
}
