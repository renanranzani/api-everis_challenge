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
    public class CareerRepositoryTest
    {
        private readonly Mock<IConfiguration> _configurationMock;

        private readonly Mock<IRepositoryConnection> _repositoryConnectionMock;

        public CareerRepositoryTest()
        {
            _configurationMock = new Mock<IConfiguration>();
            _repositoryConnectionMock = new Mock<IRepositoryConnection>();
        }

        [TestMethod]
        public void GetCareerById_Ok()
        {
            //Arrange
            var jsonDataTable = @"[
                    {
                      'CareerId': 1,
                      'CareerName': 'teste',
                      'DateRegister': '2020-05-05',
                      'CareerStatus': 'true',
                    }
                ]";

            var careerId = 1;

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetCareerById", It.IsAny<Dictionary<string, string>>())).Returns(jsonDataTable);

            //Action
            var repo = new CareerRepository(_configurationMock.Object, _repositoryConnectionMock.Object);
            var result = repo.GetCareerById(careerId);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetCareerById_Ex()
        {
            //Arrange
            var jsonDataTable = @"[{}]";

            var careerId = 1;

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetCareerById", It.IsAny<Dictionary<string, string>>())).Returns(jsonDataTable);

            //Action
            var repo = new CareerRepository(_configurationMock.Object, _repositoryConnectionMock.Object);
            var result = repo.GetCareerById(careerId);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCareerById_Null()
        {
            //Arrange
            var careerId = 1;

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetCareerById", It.IsAny<Dictionary<string, string>>()));

            //Action
            var repo = new CareerRepository(_configurationMock.Object, _repositoryConnectionMock.Object);
            var result = repo.GetCareerById(careerId);

            //Assert
            Assert.IsNull(result);
        }
    }
}
