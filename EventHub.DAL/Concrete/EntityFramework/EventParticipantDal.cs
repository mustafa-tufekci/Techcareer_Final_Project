using EventHub.Core.DataAccess.EntityFramework;
using EventHub.DAL.Abstract;
using EventHub.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.DAL.Concrete.EntityFramework
{
    public class EventParticipantDal : EfEntityRepositoryBase<EventParticipant, EventHubDbContext>, IEventParticipantDal
    {
    }
}
