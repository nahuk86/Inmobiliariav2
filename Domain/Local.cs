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

        public override void Aceptar(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}