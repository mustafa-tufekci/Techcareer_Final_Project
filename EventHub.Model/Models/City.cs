using EventHub.Core.Entities;

namespace EventHub.Entities.Models
{
    public class City : IEntity
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
    }
}
