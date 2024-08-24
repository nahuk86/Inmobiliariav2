using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CalculoImpuestoVisitor : IVisitor
    {
        public decimal Importe { get; private set; }

        public void Visit(Campo campo)
        {
            Importe = campo.Precio * 0.10m;
        }

        public void Visit(Casa casa)
        {
            Importe = casa.Precio * 0.05m;
        }

        public void Visit(Departamento departamento)
        {
            Importe = departamento.Precio * 0.01m;
        }

        public void Visit(Local local)
        {
            Importe = local.Precio * 0.12m;
        }
    }
}
