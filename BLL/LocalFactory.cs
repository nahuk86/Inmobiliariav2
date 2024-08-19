using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LocalFactory : InmuebleFactory
    {
        public override Inmueble CrearInmueble(string ubicacion, string localidad, decimal precio, Dictionary<string, object> detalles)
        {
            return new Local
            {
                Ubicacion = ubicacion,
                Localidad = localidad,
                Precio = precio,
                SuperficieTotal = (decimal)detalles["SuperficieTotal"],
                SuperficieCubierta = (decimal)detalles["SuperficieCubierta"]
            };
        }
    }
}
