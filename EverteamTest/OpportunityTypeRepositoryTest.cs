using Everteam.Interfaces;
using Everteam.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverteamTest
{
    [TestClass]
    public class OpportunityTypeRepositoryTest
    {
        private readonly Mock<IConfiguration> _configurationMock;

        private readonly Mock<IRepositoryConnection> _repositoryConnectionMock;

        public OpportunityTypeRepositoryTest()
        {
            _configurationMock = new Mock<IConfiguration>();
            _repositoryConnectionMock = new Mock<IRepositoryConnection>();
        }

        [TestMethod]
        public void GetOpportunityTypeById_Ok()
        {
            //Arrange
            var jsonDataTable = @"[
                    {
                      'OpportunityTypeId': 1,
                      'OpportunityName': 'teste',
                      'DateRegister': '2020-05-05',
                      'OpportunityTypeStatus': 'true',
                    }
                ]";

            var opportunityTypeId = 1;

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetOpportunityTypeById", It.IsAny<Dictionary<string, string>>())).Returns(jsonDataTable);

            //Action
            var repo = new OpportunityTypeRepository(_configurationMock.Object, _repositoryConnectionMock.Object);
            var result = repo.GetOpportunityTypeById(opportunityTypeId);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetOpportunityTypeById_Ex()
        {
            //Arrange
            var jsonDataTable = @"[{}]";

            var opportunityTypeId = 1;

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetOpportunityTypeById", It.IsAny<Dictionary<string, string>>())).Returns(jsonDataTable);

            //Action
            var repo = new OpportunityTypeRepository(_configurationMock.Object, _repositoryConnectionMock.Object);
            var result = repo.GetOpportunityTypeById(opportunityTypeId);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOpportunityTypeById_Null()
        {
            //Arrange
            var opportunityTypeId = 1;

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetOpportunityTypeById", It.IsAny<Dictionary<string, string>>()));

            //Action
            var repo = new OpportunityTypeRepository(_configurationMock.Object, _repositoryConnectionMock.Object);
            var result = repo.GetOpportunityTypeById(opportunityTypeId);

            //Assert
            Assert.IsNull(result);
        }
    }
}
