using EventHub.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EventHub.Entities.Models
{
    public class UserRole : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
    }
}
