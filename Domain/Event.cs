using System;
using System.Collections.Generic;

namespace Domain
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }

        public virtual ICollection<UserEvent> UserEvents { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}