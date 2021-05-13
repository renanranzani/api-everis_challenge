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
    public class ProfessionalLevelRepositoryTest
    {
        private readonly Mock<IConfiguration> _configurationMock;

        private readonly Mock<IRepositoryConnection> _repositoryConnectionMock;

        public ProfessionalLevelRepositoryTest()
        {
            _configurationMock = new Mock<IConfiguration>();
            _repositoryConnectionMock = new Mock<IRepositoryConnection>();
        }

        [TestMethod]
        public void GetProfessionalLevelById_Ok()
        {
            //Arrange
            var jsonDataTable = @"[
                    {
                      'ProfessionalLevelId': 1,
                      'ProfessionalLevelName': 'teste',
                      'ProfessionalLevelSection': 1,
                      'DateRegister': '2020-05-05',
                      'ProfessionalLevelStatus': 'true',
                    }
                ]";

            var professionalLevelId = 1;

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetProfessionalLevelById", It.IsAny<Dictionary<string, string>>())).Returns(jsonDataTable);

            //Action
            var repo = new ProfessionalLevelRepository(_configurationMock.Object, _repositoryConnectionMock.Object);
            var result = repo.GetProfessionalLevelById(professionalLevelId);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetProfessionalLevelById_Ex()
        {
            //Arrange
            var jsonDataTable = @"[{}]";

            var professionalLevelId = 1;

            _repositoryConnectionMock.Setup(x => x.SearchCommand("GetProfessionalLevelById", It.IsAny<Dictionary<string, string>>())).Returns(jsonDataTable);

            //Action
            var repo = new ProfessionalLevelRepository(_configurationMock.Object, _repositoryConnectionMock.Object);
            var result = repo.GetProfessionalLevelById(professionalLevelId);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOpportunityTypeById_Null()
        {
            //Arrange
            var professionalLevelId = 1;

            //Action
            var repo = new ProfessionalLevelRepository(_configurationMock.Object, _repositoryConnectionMock.Object);
            var result = repo.GetProfessionalLevelById(professionalLevelId);

            //Assert
            Assert.IsNull(result);
        }
    }
}