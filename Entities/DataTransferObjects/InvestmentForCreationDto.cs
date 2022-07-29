using System;
namespace Entities.DataTransferObjects
{
    public class InvestmentForCreationDto
    {
        public Guid SponsorId { get; set; }
        public Guid ProjectId { get; set; }
    }
}

