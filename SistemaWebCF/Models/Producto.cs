using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebCF.Models
{
    public class Producto
    {
        public int idproducto { get; set; }
        public int idcategoria { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public decimal precio_venta { get; set; }
        public int stock { get; set; }
        public string descripcion { get; set; }
        public bool? estado { get; set; }
        //el ambito virtual se utiliza para modificar un metodo, propiedad, indizador
        //o declaracion de evento y permite invalidar cualquiera de estos elementos 
        //en un clase derivada
        public virtual Categoria categoria { get; set; }



    }
}
