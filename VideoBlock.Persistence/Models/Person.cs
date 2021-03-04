using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VideoBlock.Persistence.Models
{
    public class Person: PersonBase
    {
        public Person()
        {
            Movies = new HashSet<PersonMovie>();
            MoviesDirected = new HashSet<Movie>();
        }

        public ICollection<PersonMovie> Movies { get; set; }
        public ICollection<Movie> MoviesDirected { get; set; }
    }
}
