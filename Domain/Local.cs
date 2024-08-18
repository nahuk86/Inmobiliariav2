using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Local : Inmueble
    {
        public decimal SuperficieTotal { get; set; }
        public decimal SuperficieCubierta { get; set; }

        public override decimal CalcularImpuesto()
        {
            return Precio * 0.12m;
        }

        public override decimal CalcularBoleto()
        {
            return Precio * 0.10m;
        }

        public override decimal CalcularCostoTotal()
        {
            decimal total = Precio + CalcularBoleto() + CalcularImpuesto();
            return total - (total * 0.05m);
        }
    }
}