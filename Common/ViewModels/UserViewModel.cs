using System.Collections.Generic;

namespace VideoBlock.Common.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Bookings { get; set; }
        public int IdRol { get; set; }
        public IList<int> BookingsId { get; set; }
    }
}
