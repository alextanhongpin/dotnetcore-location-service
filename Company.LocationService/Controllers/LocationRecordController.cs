using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Company.LocationService.Models;

namespace Company.LocationService.Controllers
{
    [Route("locations/{memberId}")]
    public class LocationRecordController : Controller
    {
        private ILocationRecordRepository _repository;
        public LocationRecordController(ILocationRecordRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AddLocation(Guid memberId, [FromBody]LocationRecord locationRecord)
        {
            if (locationRecord == null) {
                return this.BadRequest($"Error at payload");
            }
            _repository.Add(locationRecord);
            return this.Created($"/locations/{memberId}/{locationRecord.ID}", locationRecord);
        }

        [HttpGet]
        public IActionResult GetLocationsForMember(Guid memberId) 
        {
            return this.Ok(_repository.AllForMember(memberId));
        }

        [HttpGet("latest")]
        public IActionResult GetLatestForMember(Guid memberId)
        {
            return this.Ok(_repository.GetLatestForMember(memberId));
        }
    }
}
