
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Models
{
    public class OpportunityType
    {
        public int OpportunityTypeId { get; set; }
        public string OpportunityName { get; set; }
        public DateTime DateRegister { get; set; }
        public bool OpportunityTypeStatus { get; set; }

    }
}
