using Everteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Interfaces
{
    public interface IOpportunityTypeRepository
    {
        public List<OpportunityType> GetAllOpportunityTypes();
        public OpportunityType GetOpportunityTypeById(int opportunityTypeId);
        public int InsertOpportunityType(OpportunityType opportunityType);
        public void UpdateOpportunityType(OpportunityType opportunityType);
        public void DeleteOpportunityType(OpportunityType opportunityType);
    }
}