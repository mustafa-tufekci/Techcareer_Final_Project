using EventHub.BL.Abstract;
using EventHub.Core.Utilities;
using EventHub.Core.Utilities.Results;
using EventHub.DAL.Abstract;
using EventHub.DAL.Concrete.EntityFramework;
using EventHub.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.BL.Concrete
{
    public class EventParticipantManager : IEventParticipationService
    {
        IEventDal eventDal;
        IEventParticipantDal eventParticipantDal;

        public EventParticipantManager(IEventDal eventDal, IEventParticipantDal eventParticipantDal)
        {
            this.eventDal = eventDal;
            this.eventParticipantDal = eventParticipantDal;
        }

        public IResult Add(EventParticipant eventParticipant)
        {
            IResult result = BusinessRules.Run(CheckEventCapacityExceded(eventParticipant.EventID), 
                CheckIfUserRegistedSameEvent(eventParticipant.UserID, eventParticipant.EventID),
                CheckIfEventApproved(eventParticipant.EventID));

            if (result !=null)
            {
                return result;
            }

            //var @event = eventDal.Get(x => x.EventID == eventParticipant.EventID);
            //var eventModel = new Event
            //{
            //    EventID = eventParticipant.EventID,

            //};
            //eventDal.Update();
            eventParticipantDal.Add(eventParticipant);
            return new SuccessResult("Etkinliğe Kaydoldunuz");
        }

        public IResult Remove(EventParticipant eventParticipant)
        {
            throw new NotImplementedException();
        }

        private IResult CheckEventCapacityExceded(int eventid)
        {
            var result = eventDal.Get(x => x.EventID == eventid).Capacity;
            if (result < 0)
            {
                return new ErrorResult("Etkinlik kontenjanı dolu");
            }
            return new SuccessResult();
        }

        private IResult CheckIfUserRegistedSameEvent(int userid, int eventid)
        {
            var result = eventParticipantDal.GetAll(x => x.EventID == eventid && x.UserID == userid).Any();
            if (result)
            {
                return new ErrorResult("Etkinliğe zaten katıldınız");
            }
            return new SuccessResult();
        }

        private IResult CheckIfEventApproved(int eventid)
        {
            var result = eventDal.Get(x => x.EventID == eventid).ApprovalStatus;
            if (result == "Pending")
            {
                return new ErrorResult("Onaylanmamış bir etkinliğe katılamazsınız");
            }
            return new SuccessResult();
        }
    }
}
