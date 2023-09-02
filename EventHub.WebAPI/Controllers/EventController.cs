using EventHub.BL.Abstract;
using EventHub.Entities.DTOs;
using EventHub.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventController : ControllerBase
    {
        IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult CreateEvent(EventCreateDto eventCreateDto)
        {
            var createEvent = new Event
            {
                UserId = eventCreateDto.UserId,
                CityId = eventCreateDto.CityId,
                CategoryId = eventCreateDto.CategoryId,
                EventName = eventCreateDto.EventName,
                EventDescription = eventCreateDto.EventDescription,
                EventDate = eventCreateDto.EventDate,
                ApplicationDeadline = eventCreateDto.ApplicationDeadline,
                Address = eventCreateDto.Address,
                Capacity = eventCreateDto.Capacity,
                IsTicketed = eventCreateDto.IsTicketed,
                TicketPrice = eventCreateDto.TicketPrice,
                ApprovalStatus = "Pending"
            };

            var result = eventService.Add(createEvent);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateEvent(int id,[FromBody]EventUpdateDto eventUpdateDto)
        {
            var normalEvent = eventService.GetById(id);
            if (normalEvent.Success)
            {
                var date = eventService.CompareDateToNow(id);
                if (date.Success)
                {
                    var updatedEvent = new Event
                    {
                        Address = eventUpdateDto.Address,
                        Capacity= eventUpdateDto.Capacity,
                        ApplicationDeadline = normalEvent.Data.ApplicationDeadline,
                        EventDate = normalEvent.Data.EventDate,
                        EventDescription = normalEvent.Data.EventDescription,
                        EventName = normalEvent.Data.EventName,
                        ApprovalStatus= normalEvent.Data.ApprovalStatus,
                        IsTicketed = normalEvent.Data.IsTicketed,
                        TicketPrice = normalEvent.Data.TicketPrice,
                        CategoryId = normalEvent.Data.CategoryId,
                        CityId = normalEvent.Data.CityId,
                        EventID = normalEvent.Data.EventID,
                        UserId = normalEvent.Data.UserId,
                    };
                    var result = eventService.Update(updatedEvent);
                    if (result.Success)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(result.Message);
                    }
                }
            }
            return BadRequest(normalEvent);
        }

        [HttpDelete]
        [Authorize(Roles = "User")]
        public IActionResult Delete(Event @event)
        {
            var normalEvent = eventService.GetById(@event.EventID);
            if (normalEvent.Success)
            {
                var date = eventService.CompareDateToNow(@event.EventID);
                if (date.Success)
                {
                    var result = eventService.Remove(@event);
                    if (result.Success)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(result.Message);
                    }
                }
            }
            return BadRequest(normalEvent);
        }

        [HttpGet("attended/{user_id}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetJoinedEvents(int user_id)
        {
            var result = eventService.GetJoinedEvents(user_id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("will-attend/{user_id}")]
        public IActionResult GetAllByUserId(int user_id) 
        {
            var result = eventService.GetNotJoinedEvents(user_id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-user-organized-events/{user_id}")]
        [Authorize(Roles = "User")]
        public IActionResult GetUserOrganizedEvents(int user_id)
        {
            var result = eventService.GetUserEventDetails(user_id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //Admin
        [HttpGet("get-pending-approval-events")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetPendingApprovalEvents()
        {
            var result = eventService.GetPendingApprovalEvents();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("approve-event/{event_id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult ApproveEvent(int event_id)
        {
            var checkStatus = eventService.GetById(event_id);
            if (checkStatus.Data.ApprovalStatus != "Approved")
            {
                var result = eventService.UpdateEventApprovalStatus(event_id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(checkStatus.Message);
        }

        [HttpPost("reject-event/{event_id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult RejectEvent(int event_id)
        {
            var checkStatus = eventService.GetById(event_id);
            if (checkStatus.Data.ApprovalStatus != "Approved")
            {
                var updateEvent = new Event
                {
                    Address = checkStatus.Data.Address,
                    Capacity = checkStatus.Data.Capacity,
                    ApplicationDeadline = checkStatus.Data.ApplicationDeadline,
                    EventDate = checkStatus.Data.EventDate,
                    EventDescription = checkStatus.Data.EventDescription,
                    EventName = checkStatus.Data.EventName,
                    ApprovalStatus = "Rejected",
                    IsTicketed = checkStatus.Data.IsTicketed,
                    TicketPrice = checkStatus.Data.TicketPrice,
                    CategoryId = checkStatus.Data.CategoryId,
                    CityId = checkStatus.Data.CityId,
                    EventID = checkStatus.Data.EventID,
                    UserId = checkStatus.Data.UserId,
                };
                var result = eventService.Update(updateEvent);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(checkStatus.Message);
        }

        [HttpGet("categories/{category_id}")]
        public IActionResult GetEventsByCategory(int category_id)
        {
            var result = eventService.GetAllDetailsByCategory(category_id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("cities/{city_id}")]
        public IActionResult GetEventsByCity(int city_id)
        {
            var result = eventService.GetAllDetailsByCity(city_id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
