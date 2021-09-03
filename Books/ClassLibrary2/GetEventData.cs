using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace DataEntity
{
    public class GetEventData
    {
        BooksEntities booksEntities;
        public GetEventData()
        {
            booksEntities = new BooksEntities();
        }

        public List<EventObject> GetPastEvent(DateTime date, bool type)
        {
            using (booksEntities)
            {
                booksEntities.Database.Log = x => Console.WriteLine(x);
                var result = booksEntities.Event.
                     Where(x => x.Date < date && x.Type == type)
                     .Select(
                     x => new EventObject()
                     {
                         Id = x.Id,
                         Title = x.Title,
                     }).ToList();
                return result;
            }
        }

        public List<EventObject> GetFutureEvent(DateTime date, bool type)
        {
            using (booksEntities)
            {
                booksEntities.Database.Log = x => Console.WriteLine(x);
                var result = booksEntities.Event.
                    Where(x => x.Date >= date && x.Type == type)
                    .Select(
                    x => new EventObject()
                    {
                        Id = x.Id,
                        Title = x.Title,
                    }).ToList();
                return result;
            }
        }

        public EventObject GetEventDetails(int id)
        {
            using (booksEntities)
            {
                booksEntities.Database.Log = x => Console.WriteLine(x);
                var result = booksEntities.Event.
                    Where(x => x.Id == id)
                    .Select(
                    x => new EventObject()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Date = x.Date,
                        Location = x.Location,
                        StartTime = x.StartTime,
                        Duration = x.Duration,
                        Desciption = x.Desciption,
                        Others = x.Others
                    }).FirstOrDefault();
                return result;
            }
        }

        public List<EventObject> GetMyEvents(string email)
        {
            using (booksEntities)
            {
                booksEntities.Database.Log = x => Console.WriteLine(x);
                var result = booksEntities.Event.
                    Where(x => x.OwnerEmail == email)
                    .Select(
                    x => new EventObject()
                    {
                        Id = x.Id,
                        Title = x.Title,
                    }).ToList();
                return result;
            }
        }

        public List<EventObject> GetEventsInvitedTo(string email)
        {
            using (booksEntities)
            {
                booksEntities.Database.Log = x => Console.WriteLine(x);
                var result = (from x in booksEntities.Event
                    where x.Emails.Contains(email)
                    select new EventObject()
                    {
                        Id = x.Id,
                        Title = x.Title,
                    }).ToList();
                return result;
            }
        }
    }
}
