using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Business;
using FluentValidation.Results;

namespace BusinessFacade
{
    public class CreateEventLogic
    {
        public ValidationResult AddEvent(EventObject eventObject, UserObject userObject)
        {
            return new BusinessEvent().CreateEvent(eventObject, userObject);
        }

        public ValidationResult UpdateEvent(int id, EventObject eventObject)
        {
            return new BusinessEvent().EventUpdate(id, eventObject);
        }

        public bool DeleteEvent(int id)
        {
            return new BusinessEvent().DeleteEvent(id);
        }
    }
}
