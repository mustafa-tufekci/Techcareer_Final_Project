using EventHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Entities.Models
{
    public class EventParticipant : IEntity
    {
        [Key]
        public int? ParticipantID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }
    }
}
