using EventHub.Core.Entities;

namespace EventHub.Entities.Models
{
    public class Event : IEntity
    {
        public int EventID { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public int CategoryId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string Address { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public int Capacity { get; set; }
        public bool IsTicketed { get; set; }
        public double TicketPrice { get; set; }
        public string ApprovalStatus { get; set; }
    }
}
