using EventHub.Core.DataAccess;
using EventHub.Core.Utilities.Results;
using EventHub.Entities.DTOs;
using EventHub.Entities.Models;

namespace EventHub.DAL.Abstract
{
    public interface IEventDal : IEntityRepository<Event>
    {
        bool CompareDateToNow(int eventid);
        bool CapacityCheck(int eventId);
        List<EventDetailDto> GetJoinedEventDetails(int userid);
        List<EventDetailDto> GetNotJoinedEvents(int userid);
        List<EventDetailDto> GetUserEventDetails(int userid);
        List<EventDetailDto> GetEventDetails();
        List<EventDetailDto> GetAllDetailsByCategory(int category_id);
        List<EventDetailDto> GetAllDetailsByCity(int city_id);
    }
}
