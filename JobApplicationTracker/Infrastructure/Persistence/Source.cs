using SQLite;

namespace JobApplicationTracker.Infrastructure.Persistence
{
    [Table("Source")]
    public class Source
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string? DisplayText {  get; set; }
        public string? Uri { get; set; }
    }
}
