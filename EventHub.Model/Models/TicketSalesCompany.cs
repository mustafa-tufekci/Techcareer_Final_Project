using EventHub.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EventHub.Entities.Models
{
    public class TicketSalesCompany : IEntity
    {
        [Key]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string DomainName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
    }
}
