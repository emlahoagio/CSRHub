using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool isApprove { get; set; }

        public Organization Organization { get; set; }
        [ForeignKey(nameof(Organization))]
        public Guid OrgId { get; set; }

        public Sponsor Sponsor { get; set; }
        [ForeignKey(nameof(Sponsor))]
        public Guid? SponsorId { get; set; }
    }
}

