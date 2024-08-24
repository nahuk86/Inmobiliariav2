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

        public override void Aceptar(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
