using Everteam.Controllers;
using Everteam.Interfaces;
using Everteam.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverteamTest
{
    [TestClass]
    public class VacationOpportunityControllerTest
    {
        private readonly Mock<IVacationOpportunityService> _vacationOpportunityService;

        public VacationOpportunityControllerTest()
        {
            _vacationOpportunityService = new Mock<IVacationOpportunityService>();
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

            var listOpportunities = JsonConvert.DeserializeObject<List<VacationOpportunity>>(jsonDataTable);

            _vacationOpportunityService.Setup(x => x.GetAllVacationOpportunities()).Returns(listOpportunities);

            var control = new VacationOpportunityController(_vacationOpportunityService.Object);

            var result = control.GetAllVacationOpportunities();

            Assert.IsNotNull(result);
        }
    }
}
