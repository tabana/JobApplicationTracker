using SQLite;

namespace JobApplicationTracker.Infrastructure.Persistence
{
    [Table("Employer")]
    public class Employer
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string? DisplayText { get; set; }
    }
}
