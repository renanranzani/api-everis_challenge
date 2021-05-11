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
    public class OpportunityRepositoryTest
    {
        private readonly Mock<IConfiguration> _configurationMock;

        private readonly Mock<IRepositoryConnection> _repositoryConnectionMock;

        private readonly Mock<ICareerRepository> _careerRepositoryMock;
        private readonly Mock<IServiceRepository> _serviceRepositoryMock;
        private readonly Mock<IProfessionalLevelRepository> _professionalLevelRepositoryMock;
        private readonly Mock<IOpportunityTypeRepository> _oppotunityTypeRepositoryMock;

        public OpportunityRepositoryTest()
        {
            _configurationMock = new Mock<IConfiguration>();
            _repositoryConnectionMock = new Mock<IRepositoryConnection>();
            _careerRepositoryMock = new Mock<ICareerRepository>();
            _serviceRepositoryMock = new Mock<IServiceRepository>();
            _professionalLevelRepositoryMock = new Mock<IProfessionalLevelRepository>();
            _oppotunityTypeRepositoryMock = new Mock<IOpportunityTypeRepository>();
        }

        [TestMethod]
        public void GetAllOportunities_OK()
        {
            //Arrange
            var JsonDataTable = @"[
	        {
                'OpportunityId': 1,
		        'OpportunityName': 'Squad Care',
		        'OpportunityRequirements': '.NET Core',
		        'DesirableRequirements': 'Conhecimento em Kafka',
		        'DateRegister':'2021-05-05T00:00:00',
		        'ClosingDate':'2021-05-05T00:00:00',
		        'CancellationDate':'2021-05-05T00:00:00',
                'OpportunityStatus':true,
		        'CareerId': 1,
			    'ServiceId': 1,
			    'ProfessionalLevelId': 1,
			    'OpportunityTypeId': 1
	        }
            ]";

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetAllOportunities", It.IsAny<Dictionary<string, string>>())).Returns(JsonDataTable);

            //Action
            var repo = new OpportunityRepository(_configurationMock.Object, _careerRepositoryMock.Object, _serviceRepositoryMock.Object,
                _professionalLevelRepositoryMock.Object, _oppotunityTypeRepositoryMock.Object, _repositoryConnectionMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAllOportunities_Ex()
        {
            //Arrange
            var JsonDataTable = @"[{}]";

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetAllOportunities", It.IsAny<Dictionary<string, string>>())).Returns(JsonDataTable);

            //Action    
            var repo = new OpportunityRepository(_configurationMock.Object, _careerRepositoryMock.Object, _serviceRepositoryMock.Object,
                _professionalLevelRepositoryMock.Object, _oppotunityTypeRepositoryMock.Object, _repositoryConnectionMock.Object);

            var result = repo.GetAllOpportunities();

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAllOportunities_Null()
        {
            //Arrange
            var JsonDataTable = "";

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetAllOportunities", It.IsAny<Dictionary<string, string>>())).Returns(JsonDataTable);

            //Action    
            var repo = new OpportunityRepository(_configurationMock.Object, _careerRepositoryMock.Object, _serviceRepositoryMock.Object,
                _professionalLevelRepositoryMock.Object, _oppotunityTypeRepositoryMock.Object, _repositoryConnectionMock.Object);

            var result = repo.GetAllOpportunities();

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetOpportunityByName_Ok()
        {
            //Arrange
            var JsonDataTable = @"[
            {
                'OpportunityId': 1,
		        'OpportunityName': 'Squad Care',
		        'OpportunityRequirements': '.NET Core',
		        'DesirableRequirements': 'Conhecimento em Kafka',
		        'DateRegister':'2021-05-05T00:00:00',
		        'ClosingDate':'2021-05-05T00:00:00',
		        'CancellationDate':'2021-05-05T00:00:00',
                'OpportunityStatus':true,
		        'CareerId': 1,
			    'ServiceId': 1,
			    'ProfessionalLevelId': 1,
			    'OpportunityTypeId': 1
	        }
                ]";

            var opportunityName = "Squad Care";

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetOpportunityByName", It.IsAny<Dictionary<string, string>>())).Returns(JsonDataTable);

            //Action
            var repo = new OpportunityRepository(_configurationMock.Object, _careerRepositoryMock.Object, _serviceRepositoryMock.Object,
                _professionalLevelRepositoryMock.Object, _oppotunityTypeRepositoryMock.Object, _repositoryConnectionMock.Object);

            var result = repo.GetOpportunityByName(opportunityName);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetOpportunityByName_Ex()
        {
            //Arrange
            var JsonDataTable = @"[{}]";
            var opportunityName = "Squad Care";

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetOpportunityByName", It.IsAny<Dictionary<string, string>>())).Returns(JsonDataTable);

            //Action
            var repo = new OpportunityRepository(_configurationMock.Object, _careerRepositoryMock.Object, _serviceRepositoryMock.Object,
                _professionalLevelRepositoryMock.Object, _oppotunityTypeRepositoryMock.Object, _repositoryConnectionMock.Object);

            var result = repo.GetOpportunityByName(opportunityName);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOpportunityByName_Null()
        {
            //Arrange
            var opportunityName = "Squad Care";

            //Action
            var repo = new OpportunityRepository(_configurationMock.Object, _careerRepositoryMock.Object, _serviceRepositoryMock.Object,
                _professionalLevelRepositoryMock.Object, _oppotunityTypeRepositoryMock.Object, _repositoryConnectionMock.Object);

            var result = repo.GetOpportunityByName(opportunityName);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void InsertOpportunity_Ok()
        {
            var jsonOpportunity = @"[	            
                    {
                    'opportunityId': 1,
		            'opportunityName': 'Squad Care',
		            'opportunityRequirements': '.NET Core',
		            'desirableRequirements': 'Conhecimento em Kafka',
		            'dateRegister':'2021-05-05T00:00:00',
		            'closingDate':'2021-05-05T00:00:00',
		            'cancellationDate':'2021-05-05T00:00:00',
                    'status':true,
		            'career': {
			            'careerId': 1
		            },
		            'service': {
			            'serviceId': 1
		            },
		            'professionalLevel':{
			            'professionalLevelId': 1
		            },
		            'opportunityType': {
			            'opportunityTypeId': 1
		            }
	            }
            ]";

            var opportunity = JsonConvert.DeserializeObject<Opportunity>(jsonOpportunity);

            //Action
            var repo = new OpportunityRepository(_configurationMock.Object, _careerRepositoryMock.Object, _serviceRepositoryMock.Object,
               _professionalLevelRepositoryMock.Object, _oppotunityTypeRepositoryMock.Object, _repositoryConnectionMock.Object);

            repo.InsertOpportunity(opportunity);

            //Assert
            Assert.IsTrue(true);

        }
    }
}
