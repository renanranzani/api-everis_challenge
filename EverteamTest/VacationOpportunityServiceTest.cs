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
        private readonly Mock<IVacationOpportunityRepository> _VacationOpportunityRepository;

        public VacationOpportunityServiceTest()
        {
            _VacationOpportunityRepository = new Mock<IVacationOpportunityRepository>();
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
                    },
                    {
                        'VacationOpportunityId': '2',
                        'VacationOpeningNumber': 'PRE - 2020 - 0001234',
                        'VacationOpeningDate': '2021-05-05',
                        'VacationOfferLetterDate':'2021-05-05',
                        'VacationLeader': 'Thomas Anjos',
                        'VacationCancellationdate': '2021-05-05',
                        'VacationOpportunityStatus': 'false',
                        'CareerId': '1',
                        'ProfessionalLevelId': '1',
                        'OpportunityTypeId': '1',
                    }
                ]";

            var listVacationOpportunity = JsonConvert.DeserializeObject<List<VacationOpportunity>>(jsonDataTable);

            _VacationOpportunityRepository.Setup(x => x.GetAllVacationOpportunities()).Returns(listVacationOpportunity);

            var service = new VacationOpportunityService(_VacationOpportunityRepository.Object);

            var result = service.GetAllVacationOpportunities();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetVacationOpportunityByVacationLeader_Ok()
        {
            var jsonVacationOpportunity = @"
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
                    }";

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonVacationOpportunity);
            var vacationLeader = "Thomas Anjos";

            _VacationOpportunityRepository.Setup(x => x.GetVacationOpportunityByVacationLeader(vacationLeader)).Returns(vacationOpportunity);

            var service = new VacationOpportunityService(_VacationOpportunityRepository.Object);

            var result = service.GetVacationOpportunityByVacationLeader(vacationLeader);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetVacationOpportunityByOpeningDate_Ok()
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
                    },
                    {
                        'VacationOpportunityId': '2',
                        'VacationOpeningNumber': 'PRE - 2020 - 0001234',
                        'VacationOpeningDate': '2021-05-05',
                        'VacationOfferLetterDate':'2021-05-05',
                        'VacationLeader': 'Thomas Anjos',
                        'VacationCancellationdate': '2021-05-05',
                        'VacationOpportunityStatus': 'false',
                        'CareerId': '1',
                        'ProfessionalLevelId': '1',
                        'OpportunityTypeId': '1',
                    }
                ]";

            var listVacationOpportunities = JsonConvert.DeserializeObject<List<VacationOpportunity>>(jsonDataTable);

            var openingDate = DateTime.Parse("2021-05-05");

            _VacationOpportunityRepository.Setup(x => x.GetVacationOpportunityByOpeningDate(openingDate)).Returns(listVacationOpportunities);

            var service = new VacationOpportunityService(_VacationOpportunityRepository.Object);

            var result = service.GetVacationOpportunityByOpeningDate(openingDate);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void InsertVacationOpportunity_Ok()
        {
            var jsonVacationOpportunity = @"{
                        'vcationOpportunityId': '1',
                        'vacationOpeningNumber': 'PRE - 2020 - 0001234',
                        'vacationOpeningDate': '2021-05-05',
                        'vacationOfferLetterDate':'2021-05-05',
                        'vacationLeader': 'Thomas Anjos',
                        'vacationCancellationdate': '2021-05-05',
                        'vacationOpportunityStatus': 'true',
                        'career': {
                            'careerId': '1'
                        },
                        'professionalLevel': {
                            'professionalLevelId': '1'
                        },
                        'opportunityType': {
                            'opportunityTypeId': 1
                        }
                        }";

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonVacationOpportunity);

            var service = new VacationOpportunityService(_VacationOpportunityRepository.Object);

            service.InsertVacationOpportunity(vacationOpportunity);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void UpdateVacationOpportunity_Ok()
        {
            var jsonVacationOpportunity = @"{
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
                        }";

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonVacationOpportunity);

            var service = new VacationOpportunityService(_VacationOpportunityRepository.Object);

            service.UpdateVacationOpportunity(vacationOpportunity);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DeleteVacationOpportunity_Ok()
        {
            var jsonVacationOpportunity = @"{
                'vacationOpportunityId': '1'
                }";

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonVacationOpportunity);

            var service = new VacationOpportunityService(_VacationOpportunityRepository.Object);

            service.DeleteVacationOpportunity(vacationOpportunity);

            Assert.IsTrue(true);
        }
    }
}
