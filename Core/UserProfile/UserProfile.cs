using System.Collections.Generic;
using Domain;

namespace Core.UserProfile
{
    public class UserProfile
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
