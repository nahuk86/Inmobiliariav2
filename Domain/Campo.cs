using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Campo : Inmueble
    {
        public int Hectareas { get; set; }
        public bool Electricidad { get; set; }
        public bool Forestada { get; set; }

        public override void Aceptar(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}