using SQLite;

namespace JobApplicationTracker.Infrastructure.Persistence
{
    [Table("Recruiter")]
    public  class Recruiter
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Agency { get; set; }
        public string? EmailAddress { get; set; }
        public string? LinkedInUri { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
