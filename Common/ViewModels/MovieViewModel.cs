using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Título")]
        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(250, ErrorMessage = "El título no puede tener más de {1} carácteres")]
        public string Titulo { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; }
        public string Actores { get; set; }
        public int[] ActoresId { get; set; }
        public int IdDirector { get; set; }
        public string Director { get; set; }
        [Display(Name = "Costo de alquiler")]
        [Required(ErrorMessage = "El costo de alquiler es requerido")]
        public double CostoAlquiler { get; set; }
        [Display(Name = "Cantidad en inventario")]
        [Required(ErrorMessage = "La cantidad en inventario es requerida")]
        public int CantidadInventario { get; set; }
    }
}
