using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IVisitor
    {
        void Visit(Campo campo);
        void Visit(Casa casa);
        void Visit(Departamento departamento);
        void Visit(Local local);
    }
}
