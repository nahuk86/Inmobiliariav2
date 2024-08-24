using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CalculoCostoTotalVisitor : IVisitor
    {
        public decimal Importe { get; private set; }

        public void Visit(Campo campo)
        {
            var boletoVisitor = new CalculoBoletoVisitor();
            campo.Aceptar(boletoVisitor);
            var impuestoVisitor = new CalculoImpuestoVisitor();
            campo.Aceptar(impuestoVisitor);

            Importe = campo.Precio + boletoVisitor.Importe + impuestoVisitor.Importe;
        }

        public void Visit(Casa casa)
        {
            var boletoVisitor = new CalculoBoletoVisitor();
            casa.Aceptar(boletoVisitor);
            var impuestoVisitor = new CalculoImpuestoVisitor();
            casa.Aceptar(impuestoVisitor);

            Importe = casa.Precio + boletoVisitor.Importe + impuestoVisitor.Importe;
        }

        public void Visit(Departamento departamento)
        {
            var boletoVisitor = new CalculoBoletoVisitor();
            departamento.Aceptar(boletoVisitor);
            var impuestoVisitor = new CalculoImpuestoVisitor();
            departamento.Aceptar(impuestoVisitor);

            Importe = departamento.Precio + boletoVisitor.Importe + impuestoVisitor.Importe;
            Importe -= Importe * 0.05m;
        }

        public void Visit(Local local)
        {
            var boletoVisitor = new CalculoBoletoVisitor();
            local.Aceptar(boletoVisitor);
            var impuestoVisitor = new CalculoImpuestoVisitor();
            local.Aceptar(impuestoVisitor);

            Importe = local.Precio + boletoVisitor.Importe + impuestoVisitor.Importe;
            Importe -= Importe * 0.05m;
        }
    }
}