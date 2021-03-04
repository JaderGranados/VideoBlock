using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VideoBlock.Persistence.Models
{
    public class User : PersonBase
    {
        public User()
        {
            Bookings = new HashSet<Book>();
        }
        [StringLength(250)]
        public string UserName { get; set; }
        [StringLength(250)]
        public string Password { get; set; }
        public string Token { get; set; }
        public int IdRole { get; set; }

        public Role Role { get; set; }
        public ICollection<Book> Bookings { get; set; }
    }
}
