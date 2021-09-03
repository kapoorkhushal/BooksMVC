using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class EventMapping
    {
        public int Id { get; set; }
        public int? EventId { get; set; }
        public int? UserId { get; set; }

        public virtual EventObject eventObject { get; set; }
        public virtual UserObject userObject { get; set; }
    }
}
