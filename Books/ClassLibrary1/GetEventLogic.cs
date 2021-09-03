using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Business;

namespace BusinessFacade
{
    public class GetEventLogic
    {
        BusinessEvent getEventData;
        public GetEventLogic()
        {
            getEventData = new BusinessEvent();
        }

        public List<EventObject> GetPastEvent(EventObject eventObject)
        {
            return getEventData.GetPastEvent(eventObject);
        }

        public List<EventObject> GetFutureEvent(EventObject eventObject)
        {
            return getEventData.GetFutureEvent(eventObject);
        }

        public EventObject GetEventDetails(int id)
        {
            return getEventData.GetEventDetails(id);
        }

        public List<EventObject> GetMyEvents(string email)
        {
            return getEventData.GetMyEvents(email);
        }

        public List<EventObject> GetEventsInvitedTo(string email)
        {
            return getEventData.GetEventsInvitedTo(email);
        }
    }
}
