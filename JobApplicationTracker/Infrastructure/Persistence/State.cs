using SQLite;

namespace JobApplicationTracker.Infrastructure.Persistence
{
    [Table("State")]
    public class State
    {
        public Guid ApplicantId { get; set; }
        public string? CreatedDateTime { get; set; }  
    }
}
