using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CampoFactory : InmuebleFactory
    {
        public override Inmueble CrearInmueble(string ubicacion, string localidad, decimal precio, Dictionary<string, object> detalles)
        {
            return new Campo
            {
                Ubicacion = ubicacion,
                Localidad = localidad,
                Precio = precio,
                Hectareas = (int)detalles["Hectareas"],
                Electricidad = (bool)detalles["Electricidad"],
                Forestada = (bool)detalles["Forestada"]
            };
        }
    }
}
