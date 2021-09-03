using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Shared;
using DataEntity;

namespace Business
{
    public class BusinessEvent
    {
        CreateEvent createEvent;
        EventValidator eventValidator;
        GetEventData getEventData;
        public BusinessEvent()
        {
            createEvent = new CreateEvent();
            eventValidator = new EventValidator();
            getEventData = new GetEventData();
        }

        public ValidationResult CreateEvent(EventObject eventObject, UserObject userObject)
        {
            ValidationResult result = eventValidator.Validate(eventObject);
            if (result.IsValid)
            {
                CustomObject customObject = createEvent.AddEvent(eventObject, userObject);
            }
            return result;
        }

        public List<EventObject> GetPastEvent(EventObject eventObject)
        {
            return getEventData.GetPastEvent(DateTime.Now, false);
        }

        public List<EventObject> GetFutureEvent(EventObject eventObject)
        {
            return getEventData.GetFutureEvent(DateTime.Now, false);
        }

        public EventObject GetEventDetails(int id)
        {
            return getEventData.GetEventDetails(id);
        }

        public List<EventObject> GetMyEvents(string email)
        {
            return getEventData.GetMyEvents(email);
        }

        public ValidationResult EventUpdate(int id, EventObject eventObject)
        {
            ValidationResult result = eventValidator.Validate(eventObject);
            if (result.IsValid)
            {
                bool valid = createEvent.UpdateEvent(id, eventObject);
            }
            return result;
        }

        public bool DeleteEvent(int id)
        {
            return createEvent.DeleteEvent(id);
        }

        public List<EventObject> GetEventsInvitedTo(string email)
        {
            return getEventData.GetEventsInvitedTo(email);
        }
    }
}
