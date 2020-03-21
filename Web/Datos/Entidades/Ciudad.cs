using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Datos.Entidades
{
    [Table("Ciudades")]
    public class Ciudad
    {
        [Key]
        public int CiudadId { get; set; }

        [Display(Name = "Codigo")]
        [MaxLength(8, ErrorMessage = "El campo {0} debe tener una longitud maxima de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Codigo { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener una longitud maxima de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        public virtual ICollection<Vendedor> Vendedores { get; set; }
    }
}
