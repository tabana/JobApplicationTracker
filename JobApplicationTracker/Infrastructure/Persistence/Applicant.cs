using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Infrastructure.Persistence
{
    [Table("Applicant")]
    public class Applicant
    {
        [PrimaryKey]

        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? LinkedInUri { get; set; }

        [ManyToOne]
        public List<JobApplication>? JobApplications { get; set; }
    }
}
