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
    public class OpportunityServiceTest
    {
        private readonly Mock<IOpportunityRepository> _opportunityRepositoryMock;

        public OpportunityServiceTest()
        {
            _opportunityRepositoryMock = new Mock<IOpportunityRepository>();
        }

        [TestMethod]
        public void GetAllOpportunities_Ok()
        {
            var jsonDataTable = @"[
                    {
                        'OpportunityId': '1',
                        'OpportunityName': 'Squad Care',
                        'OpportunityRequirements': '.NET Core',
                        'DesirableRequirements': 'Conhecimento em Kafka',
                        'DateRegister': '2021-05-05T00:00:00',
                        'ClosingDate': '2021-05-05T00:00:00',
                        'CancellationDate': '2021-05-05T00:00:00',
                        'OpportunityStatus': true,
                        'CareerId': '1',
                        'ServiceId': '1',
                        'ProfessionalLevelId': '1',
                        'OpportunityTypeId': '1',
                    },
                    {
                        'OpportunityId': '2',
                        'OpportunityName': 'Squad Care',
                        'OpportunityRequirements': '.NET Core',
                        'DesirableRequirements': 'Conhecimento em Kafka',
                        'DateRegister': '2021-05-05T00:00:00',
                        'ClosingDate': '2021-05-05T00:00:00',
                        'CancellationDate': '2021-05-05T00:00:00',
                        'OpportunityStatus': 'false',
                        'CareerId': '1',
                        'ServiceId': '1',
                        'ProfessionalLevelId': '1',
                        'OpportunityTypeId': '1',    
                    }
                ]";

            var listOpporunities = JsonConvert.DeserializeObject<List<Opportunity>>(jsonDataTable);

            _opportunityRepositoryMock.Setup(x => x.GetAllOpportunities()).Returns(listOpporunities);

            var service = new OpportunityService(_opportunityRepositoryMock.Object);

            var result = service.GetAllOpportunities();

            Assert.IsNotNull(result);
        }
    }
}
