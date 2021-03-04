using System.ComponentModel.DataAnnotations;

namespace VideoBlock.Persistence.Models
{
    public class PersonMovie
    {
        [Key]
        public int IdMovie { get; set; }
        [Key]
        public int IdPerson { get; set; }

        public Movie Movie { get; set; }
        public Person Person { get; set; }
    }
}
