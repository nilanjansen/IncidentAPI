using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltaEndpoint.Models;
using DeltaEndpoint.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeltaEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;
        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }
        [Route("getall")]
        [HttpGet]
        public ActionResult<IEnumerable<Incident>> Get()
        {
            var incidents = _incidentService.GetAllIncident();
            return Ok(incidents);
        }

        // GET api/incident/5
        [HttpGet("{id}")]
        public ActionResult<Incident> Get(int id)
        {
            var incident = _incidentService.GetIncident(id);
            return Ok(incident);
        }

        // POST api/incident
        [HttpPost]
        public ActionResult Post([FromBody] Incident incident)
        {
            _incidentService.PostIncident(incident);
            return Ok();
        }

    }
}