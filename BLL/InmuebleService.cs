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
            InmuebleFactory factory = ObtenerFabrica(tipo);
            Inmueble inmueble = factory.CrearInmueble(ubicacion, localidad, precio, detalles);
            inmueble.FechaVenta = System.DateTime.Now;
            _repository.AgregarInmueble(inmueble);
        }

        private InmuebleFactory ObtenerFabrica(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "campo":
                    return new CampoFactory();
                case "casa":
                    return new CasaFactory();
                case "departamento":
                    return new DepartamentoFactory();
                case "local":
                    return new LocalFactory();
                default:
                    throw new System.ArgumentException("Tipo de inmueble no reconocido");
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