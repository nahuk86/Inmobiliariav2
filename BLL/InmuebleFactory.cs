using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class InmuebleFactory
    {
        public abstract Inmueble CrearInmueble(string ubicacion, string localidad, decimal precio, Dictionary<string, object> detalles);
    }
}
