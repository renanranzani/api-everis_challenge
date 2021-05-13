using Everteam.Interfaces;
using Everteam.Models;
using Everteam.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverteamTest
{
   [TestClass]
   public class VacationOpportunityServiceTest
    {
        private readonly Mock<IVacationOpportunityRepository> _vacationOpportunityRepositoryMock;

        public VacationOpportunityServiceTest()
        {
            _vacationOpportunityRepositoryMock = new Mock<IVacationOpportunityRepository>();
        }

        [TestMethod]
        public void GetAllVacationOpportunities_Ok()
        {
            var jsonDataTable = @"[
                    {
                        'VacationOpportunityId': '1',
                        'VacationOpeningNumber': 'PRE - 2020 - 0001234',
                        'VacationOpeningDate': '2021-05-05',
                        'VacationOfferLetterDate':'2021-05-05',
                        'VacationLeader': 'Thomas Anjos',
                        'VacationCancellationdate': '2021-05-05',
                        'VacationOpportunityStatus': 'true',
                        'CareerId': '1',
                        'ProfessionalLevelId': '1',
                        'OpportunityTypeId': '1',
                    }
                ]";

            var listOpporunities = JsonConvert.DeserializeObject<List<VacationOpportunity>>(jsonDataTable);

            _vacationOpportunityRepositoryMock.Setup(x => x.GetAllVacationOpportunities()).Returns(listOpporunities);

            var service = new VacationOpportunityService(_vacationOpportunityRepositoryMock.Object);

            var result = service.GetAllVacationOpportunities();

            Assert.IsNotNull(result);
        }
    }
}