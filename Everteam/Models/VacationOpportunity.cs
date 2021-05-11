using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Models
{
    public class VacationOpportunity
    {
        public int VacationOpportunityId { get; set; }
        public string VacationOpeningNumber { get; set; }
        public DateTime VacationOpeningDate { get; set; }
        public DateTime VacationOfferLetterDate { get; set; }
        public string VacationLeader { get; set; }
        public DateTime VacationCancellationDate { get; set; }
        public bool VacationOpportunityStatus { get; set; }
        public Career Career { get; set; }
        public ProfessionalLevel ProfessionalLevel { get; set; }
        public OpportunityType OpportunityType { get; set; }

    }
}
