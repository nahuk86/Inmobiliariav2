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
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al sistema de gestión inmobiliaria.");
                Console.WriteLine("Por favor, selecciona el tipo de operación:");
                Console.WriteLine("1. Vender un inmueble");
                Console.WriteLine("2. Ver inmuebles vendidos");
                Console.WriteLine("3. Salir");
                Console.Write("Ingrese el número correspondiente: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        VenderInmueble(service);
                        break;

                    case "2":
                        VerInmueblesVendidos(service);
                        break;

                    case "3":
                        continuar = false;
                        Console.WriteLine("Gracias por usar el sistema. ¡Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                if (continuar && opcion != "3")
                {
                    Console.WriteLine("\n¿Desea realizar otra operación? (S/N): ");
                    string respuesta = Console.ReadLine().ToUpper();
                    continuar = respuesta == "S";
                }
            }
        }

        static void VenderInmueble(InmuebleService service)
        {
            Console.Clear();
            Console.WriteLine("Selecciona el tipo de inmueble que deseas vender:");
            Console.WriteLine("1. Campo");
            Console.WriteLine("2. Casa");
            Console.WriteLine("3. Departamento");
            Console.WriteLine("4. Local");
            Console.Write("Ingrese el número correspondiente: ");
            string opcion = Console.ReadLine();

            string tipo = "";
            switch (opcion)
            {
                case "1":
                    tipo = "campo";
                    break;
                case "2":
                    tipo = "casa";
                    break;
                case "3":
                    tipo = "departamento";
                    break;
                case "4":
                    tipo = "local";
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    return;
            }

            Console.Write("Ingrese la ubicación: ");
            string ubicacion = Console.ReadLine();

            Console.Write("Ingrese la localidad: ");
            string localidad = Console.ReadLine();

            Console.Write("Ingrese el precio: ");
            decimal precio;
            while (!decimal.TryParse(Console.ReadLine(), out precio))
            {
                Console.WriteLine("Por favor, ingrese un valor numérico válido.");
                Console.Write("Ingrese el precio: ");
            }

            var detalles = new Dictionary<string, object>();

            switch (tipo)
            {
                case "campo":
                    Console.Write("Ingrese las hectáreas: ");
                    detalles["Hectareas"] = int.Parse(Console.ReadLine());

                    Console.Write("¿Tiene electricidad? (true/false): ");
                    detalles["Electricidad"] = bool.Parse(Console.ReadLine());

                    Console.Write("¿Está forestada? (true/false): ");
                    detalles["Forestada"] = bool.Parse(Console.ReadLine());
                    break;

                case "casa":
                    Console.Write("Ingrese la cantidad de ambientes: ");
                    detalles["CantidadAmbientes"] = int.Parse(Console.ReadLine());

                    Console.Write("Ingrese la antigüedad (en años): ");
                    detalles["Antigüedad"] = int.Parse(Console.ReadLine());
                    break;

                case "departamento":
                    Console.Write("Ingrese la cantidad de ambientes: ");
                    detalles["CantidadAmbientes"] = int.Parse(Console.ReadLine());

                    Console.Write("Ingrese la antigüedad (en años): ");
                    detalles["Antigüedad"] = int.Parse(Console.ReadLine());

                    Console.Write("Ingrese el número de departamentos por piso: ");
                    detalles["DepartamentosPorPiso"] = int.Parse(Console.ReadLine());
                    break;

                case "local":
                    Console.Write("Ingrese la superficie total (en metros cuadrados): ");
                    detalles["SuperficieTotal"] = decimal.Parse(Console.ReadLine());

                    Console.Write("Ingrese la superficie cubierta (en metros cuadrados): ");
                    detalles["SuperficieCubierta"] = decimal.Parse(Console.ReadLine());
                    break;
            }

            service.VenderInmueble(tipo, ubicacion, localidad, precio, detalles);

            Console.WriteLine("\nInmueble vendido exitosamente.");
            VerInmueblesVendidos(service);
        }

        static void VerInmueblesVendidos(InmuebleService service)
        {
            Console.WriteLine("Inmuebles vendidos:");
            var vendidos = service.ObtenerInmueblesVendidos();

            if (vendidos.Count == 0)
            {
                Console.WriteLine("No hay inmuebles vendidos.");
            }
            else
            {
                foreach (var inmuebleDto in vendidos)
                {
                    Console.WriteLine($"Tipo de Propiedad: {inmuebleDto.TipoPropiedad}");
                    Console.WriteLine($"Ubicación: {inmuebleDto.Ubicacion}");
                    Console.WriteLine($"Fecha de Venta: {inmuebleDto.FechaVenta}");
                    Console.WriteLine($"Cálculo de Impuesto: {inmuebleDto.Impuesto:C}");
                    Console.WriteLine($"Cálculo de Boleto: {inmuebleDto.Boleto:C}");
                    Console.WriteLine($"Cálculo de Propiedad: {inmuebleDto.CostoTotal:C}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}