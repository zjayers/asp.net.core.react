using System;
using System.Collections.Generic;

namespace Core.Dto
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }

        public ICollection<AttendeeDto> Attendees { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}
