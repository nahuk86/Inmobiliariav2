using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CasaFactory : InmuebleFactory
    {
        public override Inmueble CrearInmueble(string ubicacion, string localidad, decimal precio, Dictionary<string, object> detalles)
        {
            return new Casa
            {
                Ubicacion = ubicacion,
                Localidad = localidad,
                Precio = precio,
                CantidadAmbientes = (int)detalles["CantidadAmbientes"],
                Antigüedad = (int)detalles["Antigüedad"]
            };
        }
    }
}

