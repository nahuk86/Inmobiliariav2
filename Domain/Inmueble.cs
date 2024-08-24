using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Inmueble
    {
        public string Ubicacion { get; set; }
        public string Localidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaVenta { get; set; }

        public abstract void Aceptar(IVisitor visitor);
    }
}

