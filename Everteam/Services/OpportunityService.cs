using Everteam.Interfaces;
using Everteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Services
{
    public class OpportunityService : IOpportunityService
    {
        private readonly IOpportunityRepository _opportunityRepository;

        public OpportunityService(IOpportunityRepository opportunityRepository)
        {
            _opportunityRepository = opportunityRepository;
        }

        public IEnumerable<Opportunity> GetAllOpportunities()
        {
            return _opportunityRepository.GetAllOpportunities();
        }

        public Opportunity GetOpportunityByName(string opportunityName)
        {
            return _opportunityRepository.GetOpportunityByName(opportunityName);
        }

        public void InsertOpportunity(Opportunity opportunity)
        {
            _opportunityRepository.InsertOpportunity(opportunity);
        }

        public void UpdateOpportunity(Opportunity opportunity)
        {
            _opportunityRepository.UpdateOpportunity(opportunity);
        }

        public void DeleteOpportunity(Opportunity opportunity)
        {
            _opportunityRepository.DeleteOpportunity(opportunity);
        }

    }
}
