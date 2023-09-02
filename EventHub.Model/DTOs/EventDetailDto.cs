using EventHub.Core.Entities;

namespace EventHub.Entities.DTOs
{
    public class EventDetailDto : IDto
    {
        public string CategoryName { get; set; }
        public string CityName { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public string IsTicketed { get; set; }
        public double TicketPrice { get; set; }
    }
}
