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
    public class ServiceRepositoryTest
    {
        private readonly Mock<IConfiguration> _configurationMock;

        private readonly Mock<IRepositoryConnection> _repositoryConnectionMock;

        public ServiceRepositoryTest()
        {
            _configurationMock = new Mock<IConfiguration>();
            _repositoryConnectionMock = new Mock<IRepositoryConnection>();
        }

        [TestMethod]
        public void GetServiceById_Ok()
        {
            //Arrange
            var jsonDataTable = @"[
                    {
                      'ServiceId': 1,
                      'ServiceName': 'teste',
                      'DateRegister': '2020-05-05',
                      'ServiceStatus': 'true',
                    }
                ]";

            var getServiceById = 1;

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetServiceById", It.IsAny<Dictionary<string, string>>())).Returns(jsonDataTable);

            //Action
            var repo = new ServiceRepository(_configurationMock.Object, _repositoryConnectionMock.Object);
            var result = repo.GetServiceById(getServiceById);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetOpportunityTypeById_Ex()
        {
            //Arrange
            var jsonDataTable = @"[{}]";

            var getServiceById = 1;

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetServiceById", It.IsAny<Dictionary<string, string>>())).Returns(jsonDataTable);

            //Action
            var repo = new ServiceRepository(_configurationMock.Object, _repositoryConnectionMock.Object);
            var result = repo.GetServiceById(getServiceById);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOpportunityTypeById_Null()
        {
            //Arrange
            var getServiceById = 1;

            //Action
            var repo = new ServiceRepository(_configurationMock.Object, _repositoryConnectionMock.Object);
            var result = repo.GetServiceById(getServiceById);

            //Assert
            Assert.IsNull(result);
        }
    }
}
