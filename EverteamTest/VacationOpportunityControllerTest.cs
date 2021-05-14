using Everteam.Controllers;
using Everteam.Interfaces;
using Everteam.Models;
using Microsoft.AspNetCore.Mvc;
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

            var listVacationOpportunities = JsonConvert.DeserializeObject<List<VacationOpportunity>>(jsonDataTable);

            _vacationOpportunityService.Setup(x => x.GetAllVacationOpportunities()).Returns(listVacationOpportunities);

            var control = new VacationOpportunityController(_vacationOpportunityService.Object);

            var result = control.GetAllVacationOpportunities();

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
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

            var listOpportunities = JsonConvert.DeserializeObject<List<VacationOpportunity>>(jsonDataTable);

            _vacationOpportunityService.Setup(x => x.GetAllVacationOpportunities()).Returns(listOpportunities);

            var control = new VacationOpportunityController(_vacationOpportunityService.Object);

            var result = control.GetVacationOpportunityByVacationLeader(vacationLeader);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void GetVacationOpportunityByVacationLeader_BadRequest()
        {
            var opportunityName = "";

            var control = new VacationOpportunityController(_vacationOpportunityService.Object);

            var result = control.GetVacationOpportunityByVacationLeader(opportunityName);

            var badRequestResult = result as BadRequestResult;

            Assert.AreEqual(400, badRequestResult.StatusCode);
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
                    }
                ]";

            var vacationDate = DateTime.Parse("2021-05-05");

            var listOpportunities = JsonConvert.DeserializeObject<List<VacationOpportunity>>(jsonDataTable);

            _vacationOpportunityService.Setup(x => x.GetAllVacationOpportunities()).Returns(listOpportunities);

            var control = new VacationOpportunityController(_vacationOpportunityService.Object);

            var result = control.GetVacationOpportunityByOpeningDate(vacationDate);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void InsertVacationOpportunity_Ok()
        {
            var jsonDataTable = @"{
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

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonDataTable);

            var control = new VacationOpportunityController(_vacationOpportunityService.Object);

            var result = control.InsertVacationOpportunity(vacationOpportunity);

            var okResult = result as OkResult;

            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void InsertVacationOpportunity_BadRequest()
        {
            var jsonDataTable = @"";

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonDataTable);

            var control = new VacationOpportunityController(_vacationOpportunityService.Object);

            var result = control.InsertVacationOpportunity(vacationOpportunity);

            var badRequestResult = result as BadRequestResult;

            Assert.AreEqual(400, badRequestResult.StatusCode);
        }

        [TestMethod]
        public void UpdateVacationOpportunity_ok()
        {
            var jsonDataTable = @"{
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

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonDataTable);

            var control = new VacationOpportunityController(_vacationOpportunityService.Object);

            var result = control.UpdateVacationOpportunity(vacationOpportunity);

            var okResult = result as OkResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void UpdateVacationOpportunity_BadRequest()
        {
            var jsonDataTable = @"";

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonDataTable);

            var control = new VacationOpportunityController(_vacationOpportunityService.Object);

            var result = control.UpdateVacationOpportunity(vacationOpportunity);

            var badRequestResult = result as BadRequestResult;

            Assert.AreEqual(400, badRequestResult.StatusCode);
        }

        [TestMethod]
        public void DeleteVacationOpportunity_Ok()
        {
            var jsonDataTable = @"{
                'vacationOpportunityId': '1'
                }";

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonDataTable);

            var control = new VacationOpportunityController(_vacationOpportunityService.Object);

            var result = control.DeleteVacationOpportunity(vacationOpportunity);

            var okResult = result as OkResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void DeleteVacationOpportunity_BadRequest()
        {
            var jsonDataTable = @"";

            var vacationOpportunity = JsonConvert.DeserializeObject<VacationOpportunity>(jsonDataTable);

            var control = new VacationOpportunityController(_vacationOpportunityService.Object);

            var result = control.DeleteVacationOpportunity(vacationOpportunity);

            var badRequestResult = result as BadRequestResult;

            Assert.AreEqual(400, badRequestResult.StatusCode);
        }
    }
}
