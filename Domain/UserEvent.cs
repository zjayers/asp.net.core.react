using System;

namespace Domain
{
    public class UserEvent
    {
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public Guid ActivityId { get; set; }
        public virtual Event Event { get; set; }

        public DateTime DateJoined { get; set; }
        public bool IsHost { get; set; }
    }
}
