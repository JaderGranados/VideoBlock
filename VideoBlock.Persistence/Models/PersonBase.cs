using System.ComponentModel.DataAnnotations;

namespace VideoBlock.Persistence.Models
{
    public class PersonBase: ModelBase
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string LastName { get; set; }
    }
}
