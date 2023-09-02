using EventHub.BL.Abstract;
using EventHub.DAL.Concrete.EntityFramework;
using EventHub.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventHub.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="User")]
    public class EventParticipationController : ControllerBase
    {
        IEventParticipationService eventParticipationService;
        IEventService eventService;

        public EventParticipationController(IEventParticipationService eventParticipationService, IEventService eventService)
        {
            this.eventParticipationService = eventParticipationService;
            this.eventService = eventService;
        }

        [HttpPost("joinevent")]
        public IActionResult JoinEvent(EventParticipant eventParticipant)
        {
            var result = eventParticipationService.Add(eventParticipant);
            if (result.Success)
            {
                eventService.UpdateEventCapacity(eventParticipant.EventID);
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
