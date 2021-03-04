using System.ComponentModel.DataAnnotations;

namespace VideoBlock.Persistence.Models
{
    public abstract class ModelBase
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
