using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Datos.Entidades
{
    [Table("Vendedores")]
    public class Vendedor
    {
        [Key]
        public int VendedorId { get; set; }

        [Display(Name = "Codigo")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener una longitud maxima de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Codigo { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener una longitud maxima de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }


        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener una longitud maxima de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Apellido { get; set; }

        [Display(Name = "Numero de Identificacion")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener una longitud maxima de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Numero_Identificacion { get; set; }

        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }
    }
}
