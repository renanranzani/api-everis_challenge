using Everteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Interfaces
{
    public interface IVacationOpportunityService
    {
        public IEnumerable<VacationOpportunity> GetAllVacationOpportunities();
        public VacationOpportunity GetVacationOpportunityByVacationLeader(string vacationLeader);
        public IEnumerable<VacationOpportunity> GetVacationOpportunityByOpeningDate(DateTime vacationOpeningDate);
        public void InsertVacationOpportunity(VacationOpportunity vacationOpportunity);
        public void UpdateVacationOpportunity(VacationOpportunity vacationOpportunity);
        public void DeleteVacationOpportunity(VacationOpportunity vacationOpportunity);
    }
}
