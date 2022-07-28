namespace Entities.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Tag { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public bool isApprove { get; set; }

        public ICollection<Investment> Investments { get; set; }

        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}

