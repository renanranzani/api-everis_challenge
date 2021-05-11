using Everteam.Interfaces;
using Everteam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.Controllers
{
    [Route("everis/[controller]")]
    [ApiController]
    public class VacationOpportunityController : Controller
    {
        private readonly IVacationOpportunityService _vacationOpportunity;

        public VacationOpportunityController(IVacationOpportunityService vacationOpportunity)
        {
            _vacationOpportunity = vacationOpportunity;
        }

        [HttpGet]
        public IActionResult GetAllVacationOpportunities()
        {
            var listVacationOpportunities = _vacationOpportunity.GetAllVacationOpportunities();
            return Ok(listVacationOpportunities);
        }

        [HttpGet("{vacationLeader}")]
        public IActionResult GetVacationOpportunityByVacationLeader(string vacationLeader)
        {
            if (vacationLeader == "")
                return BadRequest();

            var vacationOpportunityBd = _vacationOpportunity.GetVacationOpportunityByVacationLeader(vacationLeader);
            return Ok(vacationOpportunityBd);
        }

        [HttpPost]
        public IActionResult InsertVacationOpportunity(VacationOpportunity vacationOpportunity)
        {
            if (vacationOpportunity == null)
                return BadRequest();

            _vacationOpportunity.InsertVacationOpportunity(vacationOpportunity);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateVacationOpportunity(VacationOpportunity vacationOpportunity)
        {
            if (vacationOpportunity == null)
                return BadRequest();

            _vacationOpportunity.UpdateVacationOpportunity(vacationOpportunity);
            return Ok();
        }

        [HttpPatch]
        public IActionResult DeleteVacationOpportunity(VacationOpportunity vacationOpportunity)
        {
            if (vacationOpportunity == null)
                return BadRequest();

            _vacationOpportunity.DeleteVacationOpportunity(vacationOpportunity);
            return Ok();
        }
    }
}
