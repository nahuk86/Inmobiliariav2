using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain;


namespace BLL
{
    public class InmuebleService
    {
        private readonly InmuebleRepository _repository;

        public InmuebleService()
        {
            _repository = new InmuebleRepository();
        }

        public void VenderInmueble(string tipo, string ubicacion, string localidad, decimal precio, Dictionary<string, object> detalles)
        {
            Inmueble inmueble = CrearInmueble(tipo, ubicacion, localidad, precio, detalles);
            inmueble.FechaVenta = DateTime.Now;
            _repository.AgregarInmueble(inmueble);
        }

        private Inmueble CrearInmueble(string tipo, string ubicacion, string localidad, decimal precio, Dictionary<string, object> detalles)
        {
            switch (tipo.ToLower())
            {
                case "campo":
                    return new Campo
                    {
                        Ubicacion = ubicacion,
                        Localidad = localidad,
                        Precio = precio,
                        Hectareas = (int)detalles["Hectareas"],
                        Electricidad = (bool)detalles["Electricidad"],
                        Forestada = (bool)detalles["Forestada"]
                    };
                case "casa":
                    return new Casa
                    {
                        Ubicacion = ubicacion,
                        Localidad = localidad,
                        Precio = precio,
                        CantidadAmbientes = (int)detalles["CantidadAmbientes"],
                        Antigüedad = (int)detalles["Antigüedad"]
                    };
                case "departamento":
                    return new Departamento
                    {
                        Ubicacion = ubicacion,
                        Localidad = localidad,
                        Precio = precio,
                        CantidadAmbientes = (int)detalles["CantidadAmbientes"],
                        Antigüedad = (int)detalles["Antigüedad"],
                        DepartamentosPorPiso = (int)detalles["DepartamentosPorPiso"]
                    };
                case "local":
                    return new Local
                    {
                        Ubicacion = ubicacion,
                        Localidad = localidad,
                        Precio = precio,
                        SuperficieTotal = (decimal)detalles["SuperficieTotal"],
                        SuperficieCubierta = (decimal)detalles["SuperficieCubierta"]
                    };
                default:
                    throw new ArgumentException("Tipo de inmueble no reconocido");
            }
        }

        public List<InmuebleDto> ObtenerInmueblesVendidos()
        {
            var inmuebles = _repository.ObtenerTodos();
            var inmueblesDto = new List<InmuebleDto>();

            foreach (var inmueble in inmuebles)
            {
                inmueblesDto.Add(new InmuebleDto
                {
                    TipoPropiedad = inmueble.GetType().Name,
                    Ubicacion = inmueble.Ubicacion,
                    Localidad = inmueble.Localidad,
                    Precio = inmueble.Precio,
                    FechaVenta = inmueble.FechaVenta,
                    Impuesto = inmueble.CalcularImpuesto(),
                    Boleto = inmueble.CalcularBoleto(),
                    CostoTotal = inmueble.CalcularCostoTotal()
                });
            }

            return inmueblesDto;
        }
    }
}