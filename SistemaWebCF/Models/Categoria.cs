using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebCF.Models
{
    public class Categoria

    {
        public int idcategoria { get;set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool? estado { get; set; }
        //una categoria puede tener mas de un producto
        public virtual ICollection<Producto> productos { get; set; }
    }
}
