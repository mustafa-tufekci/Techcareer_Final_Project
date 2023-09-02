using EventHub.BL.Abstract;
using EventHub.Core.Utilities.Results;
using EventHub.DAL.Abstract;
using EventHub.Entities.DTOs;
using EventHub.Entities.Models;

namespace EventHub.BL.Concrete
{
    public class EventManager : IEventService
    {
        IEventDal eventDal;

        public EventManager(IEventDal eventDal)
        {
            this.eventDal = eventDal;
        }

        public IResult CapacityCheck(int eventId)
        {
            var result = eventDal.CapacityCheck(eventId);
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult CompareDateToNow(int eventid)
        {
            var result = eventDal.CompareDateToNow(eventid);
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<Event>> GetAll(int userid)
        {
            return new SuccessDataResult<List<Event>>(eventDal.GetAll(x => x.UserId == userid));
        }

        public IDataResult<List<EventDetailDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<EventDetailDto>>(eventDal.GetEventDetails());
        }

        public IDataResult<Event> GetById(int eventId)
        {
            return new SuccessDataResult<Event>(eventDal.Get(x => x.EventID == eventId));
        }

        public IDataResult<List<EventDetailDto>> GetJoinedEvents(int userid)
        {
            return new SuccessDataResult<List<EventDetailDto>>(eventDal.GetJoinedEventDetails(userid));
        }

        public IResult Add(Event @event)
        {
            eventDal.Add(@event);
            return new SuccessResult();
        }

        public IResult Remove(Event @event)
        {
            eventDal.Delete(@event);
            return new SuccessResult();
        }

        public IResult Update(Event @event)
        {
            eventDal.Update(@event);
            return new SuccessResult();
        }

        public IResult UpdateEventCapacity(int eventid)
        {
            var result = eventDal.Get(x => x.EventID == eventid);
            result.Capacity = result.Capacity - 1;
            eventDal.Update(result);
            return new SuccessResult();
        }

        public IResult UpdateEventApprovalStatus(int eventid)
        {
            var result = eventDal.Get(x => x.EventID == eventid);
            if (result.ApprovalStatus == "Approved")
            {
                return new ErrorResult("Etkinlik zaten onaylandı");
            }
            result.ApprovalStatus = "Approved";
            eventDal.Update(result);
            return new SuccessResult("Etkinlik Onaylandı");
        }

        public IDataResult<List<EventDetailDto>> GetNotJoinedEvents(int userid)
        {
            return new SuccessDataResult<List<EventDetailDto>>(eventDal.GetNotJoinedEvents(userid));
        }
        public IDataResult<List<Event>> GetPendingApprovalEvents()
        {
            return new SuccessDataResult<List<Event>>(eventDal.GetAll(x => x.ApprovalStatus == "Pending"));
        }

        public IDataResult<List<EventDetailDto>> GetUserEventDetails(int userid)
        {
            return new SuccessDataResult<List<EventDetailDto>>(eventDal.GetUserEventDetails(userid));
        }

        public IDataResult<List<Event>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<EventDetailDto>> GetAllDetailsByCategory(int category_id)
        {
            return new SuccessDataResult<List<EventDetailDto>>(eventDal.GetAllDetailsByCategory(category_id));
        }

        public IDataResult<List<EventDetailDto>> GetAllDetailsByCity(int city_id)
        {
            return new SuccessDataResult<List<EventDetailDto>>(eventDal.GetAllDetailsByCity(city_id));

        }
    }
}
