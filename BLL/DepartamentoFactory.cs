using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartamentoFactory : InmuebleFactory
    {
        public override Inmueble CrearInmueble(string ubicacion, string localidad, decimal precio, Dictionary<string, object> detalles)
        {
            return new Departamento
            {
                Ubicacion = ubicacion,
                Localidad = localidad,
                Precio = precio,
                CantidadAmbientes = (int)detalles["CantidadAmbientes"],
                Antigüedad = (int)detalles["Antigüedad"],
                DepartamentosPorPiso = (int)detalles["DepartamentosPorPiso"]
            };
        }
    }
}
