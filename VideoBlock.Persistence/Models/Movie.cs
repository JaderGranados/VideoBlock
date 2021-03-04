using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VideoBlock.Persistence.Models
{
    public class Movie: ModelBase
    {
        public Movie()
        {
            Actors = new HashSet<PersonMovie>();
            Bookings = new HashSet<Book>();
        }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int IdDirector { get; set; }

        public Person Director { get; set; }
        public ICollection<PersonMovie> Actors { get; set; }
        public ICollection<Book> Bookings { get; set; }
    }
}
