namespace JobApplicationTracker.ViewModel
{
    public class Applicant
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? LinkedInUri { get; set; }

        public List<JobApplication>? JobApplications { get; set; }
    }
}
