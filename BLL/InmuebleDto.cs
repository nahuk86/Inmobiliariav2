using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InmuebleDto
    {
        public string TipoPropiedad { get; set; }
        public string Ubicacion { get; set; }
        public string Localidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Boleto { get; set; }
        public decimal CostoTotal { get; set; }
    }
}
