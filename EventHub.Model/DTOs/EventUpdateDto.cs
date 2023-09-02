using EventHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Entities.DTOs
{
    public class EventUpdateDto : IDto
    {
        public int Capacity { get; set; }
        public string Address { get; set; }
    }
}
