using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Departamento : Inmueble
    {
        public int CantidadAmbientes { get; set; }
        public int Antigüedad { get; set; }
        public int DepartamentosPorPiso { get; set; }

        public override decimal CalcularImpuesto()
        {
            return Precio * 0.01m;
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