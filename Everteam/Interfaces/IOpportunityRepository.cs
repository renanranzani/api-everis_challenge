using Everteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Interfaces
{
    public interface IOpportunityRepository
    {
        public List<Opportunity> GetAllOpportunities();
        public Opportunity GetOpportunityByName(string opportunityName);
        public void InsertOpportunity(Opportunity opportunity);
        public void UpdateOpportunity(Opportunity opportunity);
        public void DeleteOpportunity(Opportunity opportunity);

    }
}
