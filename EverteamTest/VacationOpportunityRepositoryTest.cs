using Everteam.Interfaces;
using Everteam.Models;
using Everteam.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EverteamTest
{
    [TestClass]
    public class VacationOpportunityRepositoryTest
    {
        private readonly Mock<IConfiguration> _configurationMock;

        private readonly Mock<IRepositoryConnection> _repositoryConnectionMock;

        private readonly Mock<ICareerRepository> _careerRepositoryMock;

        private readonly Mock<IProfessionalLevelRepository> _professionalLevelRepositoryMock;

        private readonly Mock<IOpportunityTypeRepository> _opportunityTypeRepository;

        public VacationOpportunityRepositoryTest()
        {
            _configurationMock = new Mock<IConfiguration>();
            _repositoryConnectionMock = new Mock<IRepositoryConnection>();
            _careerRepositoryMock = new Mock<ICareerRepository>();
            _professionalLevelRepositoryMock = new Mock<IProfessionalLevelRepository>();
            _opportunityTypeRepository = new Mock<IOpportunityTypeRepository>();
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
            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetAllVacationOpportunities", It.IsAny<Dictionary<string, string>>())).Returns(jsonDataTable);

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object, 
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            var result = repo.GetAllVacationOpportunities();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetAllVacationOpportunities_ArgumentException()
        {
            var jsonDataTable = @"[{}]";

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetAllVacationOpportunities", It.IsAny<Dictionary<string, string>>())).Returns(jsonDataTable);

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            var result = repo.GetAllVacationOpportunities();

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAllVacationOpportunities_ArgumentNullException()
        {
            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            var result = repo.GetAllVacationOpportunities();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetVacationOpportunityByVacationLeader_Ok()
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

            var vacationLeader = "Thomas Anjos";
            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetVacationOpportunityByVacationLeader", It.IsAny<Dictionary<string, string>>())).Returns(jsonDataTable);

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            var result = repo.GetVacationOpportunityByVacationLeader(vacationLeader);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetVacationOpportunityByVacationLeader_ArgumentException()
        {
            var jsonDataTable = @"[{}]";

            var vacationLeader = "Thomas Anjos";

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetVacationOpportunityByVacationLeader", It.IsAny<Dictionary<string, string>>())).Returns(jsonDataTable);

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            var result = repo.GetVacationOpportunityByVacationLeader(vacationLeader);

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetVacationOpportunityByVacationLeader_ArgumentNullException()
        {
            var vacationLeader = "Thomas Anjos";

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            var result = repo.GetVacationOpportunityByVacationLeader(vacationLeader);

            Assert.IsNull(result);
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

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            repo.InsertVacationOpportunity(vacationOpportunity);

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void InsertVacationOpportunity_NullReferenceException()
        {
            var jsonVacationOpportunity = @" ";

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonVacationOpportunity);

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            repo.InsertVacationOpportunity(vacationOpportunity);

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InsertVacationOpportunity_Exception()
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
            var vacationOpportuinity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonVacationOpportunity);

            _repositoryConnectionMock.Setup(x => x.SimpleExecuteCommand("InsertVacationOpportunity", It.IsAny<Dictionary<string, string>>())).Throws(new Exception());

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            repo.InsertVacationOpportunity(vacationOpportuinity);

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

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            repo.UpdateVacationOpportunity(vacationOpportunity);

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public  void UpdateVacationOpportunity_NullReferenceException()
        {
            var jsonVacationOpportunity = @" ";

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonVacationOpportunity);

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            repo.UpdateVacationOpportunity(vacationOpportunity);

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UpdateVacationOpportunity_Exception()
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

            _repositoryConnectionMock.Setup(x => x.SimpleExecuteCommand("UpdateVacationOpportunity", It.IsAny<Dictionary<string, string>>())).Throws(new Exception());

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            repo.UpdateVacationOpportunity(vacationOpportunity);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DeleteVacationOpportunity_Ok()
        {
            var jsonVacationOpportunity = @"{
                'vacationOpportunityId': '1'
                }";

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonVacationOpportunity);

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            repo.DeleteVacationOpportunity(vacationOpportunity);

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteVacationOpportunity_NullReferenceException()
        {
            var jsonVacationOpportunity = @" ";

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonVacationOpportunity);

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            repo.DeleteVacationOpportunity(vacationOpportunity);

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeleteVacationOpportunity_Exception()
        {
            var jsonVacationOpportunity = @"{
                'vacationOpportunityId': '1'
                }";

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonVacationOpportunity);

            _repositoryConnectionMock.Setup(x => x.SimpleExecuteCommand("DeleteVacationOpportunity", It.IsAny<Dictionary<string, string>>())).Throws(new Exception());

            var repo = new VacationOpportunityRepository(_configurationMock.Object, _repositoryConnectionMock.Object, _careerRepositoryMock.Object,
                                                         _professionalLevelRepositoryMock.Object, _opportunityTypeRepository.Object);

            repo.DeleteVacationOpportunity(vacationOpportunity);

            Assert.IsTrue(true);
        }
    }
}
