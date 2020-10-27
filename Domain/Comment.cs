using System;


namespace Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual AppUser Author { get; set; }
        public virtual Event Event { get; set; }
    }
}
