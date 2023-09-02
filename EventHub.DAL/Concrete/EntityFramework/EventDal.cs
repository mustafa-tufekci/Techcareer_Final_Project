using EventHub.Core.DataAccess.EntityFramework;
using EventHub.DAL.Abstract;
using EventHub.Entities.DTOs;
using EventHub.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EventHub.DAL.Concrete.EntityFramework
{
    public class EventDal : EfEntityRepositoryBase<Event, EventHubDbContext>, IEventDal
    {
        public bool CapacityCheck(int eventId)
        {
            using (var context= new EventHubDbContext())
            {
                var result = context.Events
                    .Where(e => e.EventID == eventId)
                    .Select(e => e.Capacity > 0)
                    .FirstOrDefault();

                return result;
            }
        }

        public bool CompareDateToNow(int eventid)
        {
            using (var context = new EventHubDbContext())
            {
                var currentDate = DateTime.Now;

                var result = context.Events
                    .Where(e => e.EventID == eventid)
                    .Select(e => Math.Abs((currentDate - e.ApplicationDeadline).Days) > 5)
                    .FirstOrDefault();

                return result;
            }
        }

        public List<EventDetailDto> GetAllDetailsByCategory(int category_id)
        {
            using(var context = new EventHubDbContext()) 
            {
                var result = from e in context.Events
                             join ca in context.Categories
                             on e.CategoryId equals ca.CategoryID
                             join c in context.Cities
                             on e.CityId equals c.CityID
                             where e.CategoryId == category_id
                             && e.ApprovalStatus == "Approved"
                             select new EventDetailDto
                             {
                                 EventName = e.EventName,
                                 CategoryName = ca.CategoryName,
                                 CityName = c.CityName,
                                 EventDate = e.EventDate,
                                 ApplicationDeadline = e.ApplicationDeadline,
                                 Address = e.Address,
                                 Capacity = e.Capacity,
                                 IsTicketed = e.IsTicketed ? "Biletli" : "Biletsiz",
                                 TicketPrice = e.TicketPrice
                             };

                return result.ToList();
            }
        }

        public List<EventDetailDto> GetAllDetailsByCity(int city_id)
        {
            using (var context = new EventHubDbContext())
            {
                var result = from e in context.Events
                             join ca in context.Categories
                             on e.CategoryId equals ca.CategoryID
                             join c in context.Cities
                             on e.CityId equals c.CityID
                             where e.CityId == city_id
                             && e.ApprovalStatus == "Approved"
                             select new EventDetailDto
                             {
                                 EventName = e.EventName,
                                 CategoryName = ca.CategoryName,
                                 CityName = c.CityName,
                                 EventDate = e.EventDate,
                                 ApplicationDeadline = e.ApplicationDeadline,
                                 Address = e.Address,
                                 Capacity = e.Capacity,
                                 IsTicketed = e.IsTicketed ? "Biletli" : "Biletsiz",
                                 TicketPrice = e.TicketPrice
                             };

                return result.ToList();
            }
        }

        public List<EventDetailDto> GetEventDetails()
        {
            using (var context = new EventHubDbContext())
            {
                var result = from e in context.Events
                             join ca in context.Categories
                             on e.CategoryId equals ca.CategoryID
                             join c in context.Cities
                             on e.CityId equals c.CityID
                             where e.ApprovalStatus == "Approved"
                             select new EventDetailDto
                             {
                                 EventName = e.EventName,
                                 CategoryName = ca.CategoryName,
                                 CityName = c.CityName,
                                 EventDate = e.EventDate,
                                 ApplicationDeadline = e.ApplicationDeadline,
                                 Address = e.Address,
                                 Capacity = e.Capacity,
                                 IsTicketed = e.IsTicketed ? "Biletli" : "Biletsiz",
                                 TicketPrice = e.TicketPrice
                             };

                return result.ToList();
            }
        }

        public List<EventDetailDto> GetJoinedEventDetails(int userid)
        {
            using (var context = new EventHubDbContext())
            {
                var result = from e in context.Events
                             join ca in context.Categories
                             on e.CategoryId equals ca.CategoryID
                             join c in context.Cities
                             on e.CityId equals c.CityID
                             join ep in context.EventParticipants
                             on e.EventID equals ep.EventID
                             where ep.UserID == userid
                             select new EventDetailDto
                             {
                                 EventName = e.EventName,
                                 CategoryName = ca.CategoryName,
                                 CityName = c.CityName,
                                 EventDate = e.EventDate,
                                 ApplicationDeadline = e.ApplicationDeadline,
                                 Address = e.Address,
                                 Capacity = e.Capacity,
                                 IsTicketed = e.IsTicketed ? "Biletli" : "Biletsiz",
                                 TicketPrice = e.TicketPrice
                             };

                return result.ToList();
            }
        }

        public List<EventDetailDto> GetNotJoinedEvents(int userid)
        {
            using (var context = new EventHubDbContext())
            {
                var result = from e in context.Events
                             join ca in context.Categories
                             on e.CategoryId equals ca.CategoryID
                             join c in context.Cities
                             on e.CityId equals c.CityID
                             join ep in context.EventParticipants
                             on e.EventID equals ep.EventID
                             where ep.UserID != userid
                             
                             select new EventDetailDto
                             {
                                 EventName = e.EventName,
                                 CategoryName = ca.CategoryName,
                                 CityName = c.CityName,
                                 EventDate = e.EventDate,
                                 ApplicationDeadline = e.ApplicationDeadline,
                                 Address = e.Address,
                                 Capacity = e.Capacity,
                                 IsTicketed = e.IsTicketed ? "Biletli" : "Biletsiz",
                                 TicketPrice = e.TicketPrice
                             };

                return result.ToList();
            }
        }

        public List<EventDetailDto> GetUserEventDetails(int userid)
        {
            using (var context = new EventHubDbContext())
            {
                var result = from e in context.Events
                             join ca in context.Categories
                             on e.CategoryId equals ca.CategoryID
                             join c in context.Cities
                             on e.CityId equals c.CityID
                             where e.UserId == userid
                             select new EventDetailDto
                             {
                                 EventName = e.EventName,
                                 CategoryName = ca.CategoryName,
                                 CityName = c.CityName,
                                 EventDate = e.EventDate,
                                 ApplicationDeadline = e.ApplicationDeadline,
                                 Address = e.Address,
                                 Capacity = e.Capacity,
                                 IsTicketed = e.IsTicketed ? "Biletli" : "Biletsiz",
                                 TicketPrice = e.TicketPrice
                             };

                return result.ToList();
            }
        }
    }
}
