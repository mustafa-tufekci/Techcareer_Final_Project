using EventHub.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EventHub.Entities.Models
{
    public class Role : IEntity
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Permissions { get; set; }
    }
}
