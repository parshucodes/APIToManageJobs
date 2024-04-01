namespace ManageJobs.Models
{
    public class Jobs
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Title { get; set; }
        
        public string? Department { get; set; }
        public string? Location { get; set; }

        public DateTime PostedDate { get; set; } = DateTime.UtcNow;
        public DateTime ClosingDate { get; set; }
    }
}
