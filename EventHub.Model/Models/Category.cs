using EventHub.Core.Entities;

namespace EventHub.Entities.Models
{
    public class Category : IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
