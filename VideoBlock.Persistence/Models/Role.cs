using System.Collections.Generic;

namespace VideoBlock.Persistence.Models
{
    public class Role: ModelBase
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
