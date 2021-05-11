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
    [ApiController]
    [Route("everis/[controller]")]
    public class OpportunityController : Controller
    {
        private readonly IOpportunityService _opportunity;

        public OpportunityController(IOpportunityService opportunity)
        {
            _opportunity = opportunity;
        }

        [HttpGet]
        public IActionResult GetAllOpportunities()
        {
            var listOpportunities = _opportunity.GetAllOpportunities();
            return Ok(listOpportunities);
        }

        [HttpGet("{opportunityName}")]
        public IActionResult GetOpportunityByName(string opportunityName)
        {
            if (opportunityName == "")
                return BadRequest();

            var opportunityBd = _opportunity.GetOpportunityByName(opportunityName);
            return Ok(opportunityBd);
        }

        [HttpPost]
        public IActionResult InsertOpportunity(Opportunity opportunity)
        {
            if (opportunity == null)
                return BadRequest();

            _opportunity.InsertOpportunity(opportunity);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateOpportunity(Opportunity opportunity)
        {
            if (opportunity == null)
                return BadRequest();

            _opportunity.UpdateOpportunity(opportunity);
            return Ok();
        }

        [HttpPatch]
        public IActionResult DeleteOpportunity(Opportunity opportunity)
        {
            if (opportunity == null)
                return BadRequest();

            _opportunity.DeleteOpportunity(opportunity);
            return Ok();
        }
    }
}
