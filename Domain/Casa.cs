using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Casa : Inmueble
    {
        public int CantidadAmbientes { get; set; }
        public int Antigüedad { get; set; }

        public override decimal CalcularImpuesto()
        {
            return Precio * 0.05m;
        }

        public override decimal CalcularBoleto()
        {
            return Precio * 0.10m;
        }

        public override decimal CalcularCostoTotal()
        {
            return Precio + CalcularBoleto() + CalcularImpuesto();
        }
    }
}