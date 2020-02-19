using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebCF.Models
{
    public class Categoria

    {
        public int idcategoria { get;set; }
        [Display(Name ="Nombre")]
        [Required(ErrorMessage = "Ingrese un nombre.")]
        [StringLength(50, MinimumLength = 3,
    ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        [Display(Name = "Descripcion")]
        [StringLength(255,
    ErrorMessage = "la descripción no debe de tener más de 255 caracteres.")]
        public string descripcion { get; set; }
        [Display(Name = "Estado")]
        public bool? estado { get; set; }
        //una categoria puede tener mas de un producto
        public virtual ICollection<Producto> productos { get; set; }
    }
}
