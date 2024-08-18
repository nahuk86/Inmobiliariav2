using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new InmuebleService();

            // Creación de un nuevo Campo a través de la BLL
            var detallesCampo = new Dictionary<string, object>
            {
                { "Hectareas", 50 },
                { "Electricidad", true },
                { "Forestada", false }
            };

            service.VenderInmueble("campo", "Rural", "Santa Fe", 1500000m, detallesCampo);

            // Obtener y mostrar inmuebles vendidos
            var vendidos = service.ObtenerInmueblesVendidos();

            foreach (var inmuebleDto in vendidos)
            {
                Console.WriteLine($"Tipo Propiedad: {inmuebleDto.TipoPropiedad}, " +
                                  $"Ubicación: {inmuebleDto.Ubicacion}, " +
                                  $"Fecha de Venta: {inmuebleDto.FechaVenta}");
                Console.WriteLine($"Cálculo de Impuesto: {inmuebleDto.Impuesto}");
                Console.WriteLine($"Cálculo de Boleto: {inmuebleDto.Boleto}");
                Console.WriteLine($"Cálculo de Propiedad: {inmuebleDto.CostoTotal}");
                Console.WriteLine();
            }


            Console.WriteLine("Presiona Enter para salir...");
            Console.ReadLine();
        }
    }
}