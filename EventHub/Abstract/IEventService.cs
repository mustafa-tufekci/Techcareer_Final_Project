using EventHub.Core.Utilities.Results;
using EventHub.Entities.DTOs;
using EventHub.Entities.Models;

namespace EventHub.BL.Abstract
{
    public interface IEventService
    {
        IDataResult<List<EventDetailDto>> GetAllDetails();
        IDataResult<List<EventDetailDto>> GetJoinedEvents(int userid);
        IDataResult<List<EventDetailDto>> GetNotJoinedEvents(int userid);
        IDataResult<List<EventDetailDto>> GetUserEventDetails(int userid);
        IDataResult<List<EventDetailDto>> GetAllDetailsByCategory(int category_id);
        IDataResult<List<EventDetailDto>> GetAllDetailsByCity(int city_id);
        IDataResult<List<Event>> GetPendingApprovalEvents();
        IDataResult<List<Event>> GetAll();
        IDataResult<Event> GetById(int eventId);
        IResult Add(Event @event);
        IResult Remove(Event @event);
        IResult Update(Event @event);
        IResult UpdateEventCapacity(int eventid);
        IResult UpdateEventApprovalStatus(int eventid);
        IResult CompareDateToNow(int eventid);
        IResult CapacityCheck(int eventId);
    }
}
