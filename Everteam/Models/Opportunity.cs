using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Models
{
    public class Opportunity
    {
        public int OpportunityId { get; set; }
        public string OpportunityName { get; set; }
        public string OpportunityRequirements { get; set; }
        public string DesirableRequirements { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime ClosingDate { get; set; }
        public DateTime CancellationDate { get; set; }
        public bool OpportunityStatus { get; set; }
        public Career Career { get; set; }
        public Service Service { get; set; }
        public ProfessionalLevel ProfessionalLevel { get; set; }
        public OpportunityType OpportunityType { get; set; }

    }
}
