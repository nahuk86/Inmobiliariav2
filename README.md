En la solución que hemos ido desarrollando, se han utilizado algunos patrones de diseño clave que permiten mantener una arquitectura en capas bien organizada, flexible y mantenible. A continuación, detallo los patrones de diseño utilizados y por qué son apropiados en este contexto:

### 1. **Patrón DTO (Data Transfer Object)**
   - **Uso:** El patrón DTO fue implementado en la capa **BLL** para transferir datos entre la capa de lógica de negocio y la UI. El `InmuebleDto` es un objeto que encapsula la información necesaria para ser mostrada en la UI, sin exponer las entidades de dominio directamente.
   
   **Motivo:**
   - **Separación de responsabilidades:** Al usar un DTO, evitamos que la UI tenga acceso directo a las entidades del dominio (`Domain`). De esta manera, la UI solo recibe los datos que necesita sin acceder ni modificar directamente las entidades del negocio.
   - **Simplicidad y seguridad:** El DTO asegura que solo los datos relevantes son enviados a la capa de presentación, manteniendo las entidades de dominio encapsuladas en la lógica de negocio y evitando filtraciones innecesarias de lógica de dominio a la UI.

   **Ventaja:** Facilita la separación entre la lógica de negocio y la presentación, lo que ayuda a mantener el código más limpio y a reducir el acoplamiento entre capas.

   **Código del DTO:**
   ```csharp
   public class InmuebleDto
   {
       public string TipoPropiedad { get; set; }
       public string Ubicacion { get; set; }
       public string Localidad { get; set; }
       public decimal Precio { get; set; }
       public DateTime FechaVenta { get; set; }
       public decimal Impuesto { get; set; }
       public decimal Boleto { get; set; }
       public decimal CostoTotal { get; set; }
   }
   ```

### 2. **Patrón Factory Method (Método de fábrica)**
   - **Uso:** Aunque no se implementó directamente una clase `Factory`, utilizamos un método `CrearInmueble` dentro del servicio en la BLL para construir los diferentes tipos de `Inmueble` (como `Casa`, `Campo`, `Departamento`, etc.), basado en el tipo de propiedad pasado como argumento.

   **Motivo:**
   - **Flexibilidad en la creación de objetos:** Usamos el patrón Factory Method dentro de la BLL para encapsular la lógica de creación de los diferentes tipos de inmuebles. Esto permite que la UI no necesite conocer los detalles de cómo crear un `Inmueble`, simplificando su responsabilidad.
   - **Polimorfismo:** El método `CrearInmueble` se encarga de devolver un tipo específico de inmueble (`Casa`, `Departamento`, `Local`), pero desde la perspectiva de la lógica de negocio, trabajamos con el tipo base `Inmueble`, aprovechando el polimorfismo.

   **Ventaja:** Mantiene la lógica de creación encapsulada en un solo lugar, lo que facilita la adición de nuevos tipos de inmuebles sin tener que modificar la UI o la lógica en varias partes.

   **Código de Factory Method:**
   ```csharp
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
   ```

### 3. **Patrón Repository (Repositorio)**
   - **Uso:** El patrón repositorio fue implementado en la capa **DAL** mediante la clase `InmuebleRepository`, que se encarga de gestionar el acceso a los datos, como almacenar y recuperar los inmuebles vendidos.

   **Motivo:**
   - **Abstracción del acceso a los datos:** El patrón repositorio permite encapsular todas las operaciones relacionadas con la persistencia de datos en un único lugar. De esta manera, el código que maneja la lógica de negocio no necesita preocuparse por cómo los datos son almacenados o recuperados.
   - **Fácil mantenimiento y extensión:** Si decides cambiar la fuente de datos (por ejemplo, de una lista en memoria a una base de datos), solo necesitarás modificar el repositorio sin afectar el resto del sistema.

   **Ventaja:** Facilita el mantenimiento y la escalabilidad del sistema, ya que el acceso a los datos está centralizado y desacoplado de la lógica de negocio.

   **Código del Repositorio:**
   ```csharp
   using Inmobiliaria.Domain;
   using System.Collections.Generic;

   namespace Inmobiliaria.DAL
   {
       public class InmuebleRepository
       {
           private List<Inmueble> _inmuebles = new List<Inmueble>();

           public void AgregarInmueble(Inmueble inmueble)
           {
               _inmuebles.Add(inmueble);
           }

           public List<Inmueble> ObtenerTodos()
           {
               return _inmuebles;
           }
       }
   }
   ```

### 4. **Patrón de Capas (Layered Architecture)**
   - **Uso:** La solución se organiza en capas separadas (Domain, BLL, DAL, y UI), con cada capa cumpliendo una función específica.

   **Motivo:**
   - **Separación de responsabilidades:** Cada capa tiene una responsabilidad clara: la **UI** maneja la entrada y salida de datos, la **BLL** contiene la lógica de negocio, el **DAL** se encarga del acceso a los datos, y el **Domain** contiene las entidades del negocio.
   - **Reducción del acoplamiento:** Cada capa solo interactúa con la capa inmediatamente adyacente, lo que facilita la mantenibilidad del sistema. Si hay cambios en una capa, las otras no se ven afectadas.

   **Ventaja:** Esta organización modular permite una alta cohesión dentro de cada capa y un bajo acoplamiento entre ellas, lo que hace el sistema más flexible y fácil de mantener.

---

### Resumen:
- **DTO (Data Transfer Object):** Usado para transferir datos entre capas de forma eficiente y segura, evitando que la UI interactúe directamente con las entidades de dominio.
- **Factory Method:** Usado para crear instancias de diferentes tipos de inmuebles en función de los datos recibidos, encapsulando la lógica de creación.
- **Repository (Repositorio):** Implementado para abstraer el acceso a los datos y centralizar las operaciones relacionadas con el almacenamiento y recuperación de inmuebles.
- **Patrón de Capas:** Implementado para asegurar una correcta separación de responsabilidades y un bajo acoplamiento entre las diferentes partes del sistema.

Estos patrones permiten que el sistema sea más mantenible, extensible y fácil de entender, cumpliendo con los principios de diseño de software como la separación de responsabilidades y el principio de inversión de dependencias.
