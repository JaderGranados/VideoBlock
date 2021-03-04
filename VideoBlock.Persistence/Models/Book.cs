using System.ComponentModel.DataAnnotations;

namespace VideoBlock.Persistence.Models
{
    public class Book
    {
        [Key]
        public int IdUser { get; set; }
        [Key]
        public int IdMovie { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
