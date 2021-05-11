using Everteam.Interfaces;
using Everteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Services
{
    public class VacationOpportunityService : IVacationOpportunityService
    {
        private readonly IVacationOpportunityRepository _vacationOpportunityRepository;

        public VacationOpportunityService(IVacationOpportunityRepository vacationOpportunityRepository)
        {
            _vacationOpportunityRepository = vacationOpportunityRepository;
        }

        public IEnumerable<VacationOpportunity> GetAllVacationOpportunities()
        {
            return _vacationOpportunityRepository.GetAllVacationOpportunities();
        }

        public VacationOpportunity GetVacationOpportunityByVacationLeader(string vacationLeader)
        {
            return _vacationOpportunityRepository.GetVacationOpportunityByVacationLeader(vacationLeader);
        }

        public void InsertVacationOpportunity(VacationOpportunity vacationOpportunity)
        {
            _vacationOpportunityRepository.InsertVacationOpportunity(vacationOpportunity);
        }

        public void UpdateVacationOpportunity(VacationOpportunity vacationOpportunity)
        {
            _vacationOpportunityRepository.UpdateVacationOpportunity(vacationOpportunity);
        }

        public void DeleteVacationOpportunity(VacationOpportunity vacationOpportunity)
        {
            _vacationOpportunityRepository.DeleteVacationOpportunity(vacationOpportunity);
        }
    }
}
