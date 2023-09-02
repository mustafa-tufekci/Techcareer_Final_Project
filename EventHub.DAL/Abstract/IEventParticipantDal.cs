using EventHub.Core.DataAccess;
using EventHub.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.DAL.Abstract
{
    public interface IEventParticipantDal : IEntityRepository<EventParticipant>
    {
    }
}
