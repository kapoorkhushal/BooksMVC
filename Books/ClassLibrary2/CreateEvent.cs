using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace DataEntity
{
    public class CreateEvent
    {
        public CustomObject AddEvent(EventObject eventObject, UserObject userObject)
        {
            BooksEntities booksEntities = new BooksEntities();
            CustomObject customObject = new CustomObject();
            Event events = new Event()
            {
                Title = eventObject.Title,
                Date = eventObject.Date,
                Location = eventObject.Location,
                StartTime = eventObject.StartTime,
                Type = eventObject.Type,
                Duration = eventObject.Duration,
                Desciption = eventObject.Desciption,
                Others = eventObject.Others,
                Emails = eventObject.Emails,
                OwnerEmail = userObject.Email
            };
            booksEntities.Event.Add(events);
            int value = booksEntities.SaveChanges();
            if(0 < value)
            {
                customObject.CustomMessage = "Event created Successfully!";
                customObject.CustomMessageNumber = value;
            }
            else
            {
                customObject.CustomMessage = "There is some problem creating new Event!";
                customObject.CustomMessageNumber = value;
            }
            return customObject;
        }

        public bool UpdateEvent(int id, EventObject eventObject)
        {
            using (var context = new BooksEntities())
            {
                var updatedEvent = context.Event.FirstOrDefault(x => x.Id == id);
                if(updatedEvent != null)
                {
                    updatedEvent.Title = eventObject.Title;
                    updatedEvent.Date = eventObject.Date;
                    updatedEvent.Location = eventObject.Location;
                    updatedEvent.StartTime = eventObject.StartTime;
                    updatedEvent.Type = eventObject.Type;
                    updatedEvent.Duration = eventObject.Duration;
                    updatedEvent.Desciption = eventObject.Desciption;
                    updatedEvent.Others = eventObject.Others;
                    updatedEvent.Emails = eventObject.Emails;
                }
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteEvent(int id)
        {
            using (var context = new BooksEntities())
            {
                var deletedEvent = context.Event.FirstOrDefault(x => x.Id == id);
                if(null != deletedEvent)
                {
                    var deletedEventMap = context.EventMapping.FirstOrDefault(x => x.EventId == id);
                    if(null != deletedEventMap)
                    {
                        context.EventMapping.Remove(deletedEventMap);
                    }
                    context.Event.Remove(deletedEvent);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
