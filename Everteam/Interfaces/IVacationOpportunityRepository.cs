using Everteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Interfaces
{
    public interface IVacationOpportunityRepository
    {
        public List<VacationOpportunity> GetAllVacationOpportunities();
        public VacationOpportunity GetVacationOpportunityByVacationLeader(string vacationLeader);
        public List<VacationOpportunity> GetVacationOpportunityByOpeningDate(DateTime vacationOpeningDate);
        public void InsertVacationOpportunity(VacationOpportunity vacationOpportunity);
        public void UpdateVacationOpportunity(VacationOpportunity vacationOpportunity);
        public void DeleteVacationOpportunity(VacationOpportunity vacationOpportunity);
    }
}
