using EventHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Entities.DTOs
{
    public class UserToUpdateDto : IDto
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
