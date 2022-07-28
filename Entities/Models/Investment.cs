using System;
namespace Entities.Models
{
    public class Investment
    {
        public Guid SponsorId { get; set; }
        public Sponsor Sponsor { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}

