### Documentación del Proyecto Inmobiliario

#### Descripción General
Este proyecto es una aplicación de consola desarrollada en C# que simula la gestión de una inmobiliaria, permitiendo la venta de diversos tipos de inmuebles (Casa, Departamento, Local y Campo). La aplicación utiliza una arquitectura en capas y varios patrones de diseño para asegurar un código modular, mantenible y extensible.

#### Estructura del Proyecto

El proyecto está dividido en cuatro capas principales:

1. **Domain**: Contiene las entidades del negocio (Casa, Departamento, Local, Campo) y los visitantes (patrón Visitor) que realizan operaciones sobre estas entidades.
2. **BLL (Business Logic Layer)**: Maneja la lógica de negocio a través de la clase `InmuebleService` y utiliza el patrón Factory para la creación de inmuebles y el patrón Visitor para realizar cálculos.
3. **DAL (Data Access Layer)**: Gestiona el acceso a los datos, simulando un repositorio en memoria a través de la clase `InmuebleRepository`.
4. **UI (User Interface)**: Interactúa con el usuario a través de la consola, permite la venta de inmuebles y muestra la información relacionada con los inmuebles vendidos.

### Patrones de Diseño Utilizados

1. **Patrón Factory**
   - **Descripción**: Se utiliza el patrón Factory para encapsular la creación de los diferentes tipos de inmuebles (`Casa`, `Departamento`, `Local`, `Campo`). Esto permite que la lógica de creación esté centralizada en una fábrica específica, lo que facilita la adición de nuevos tipos de inmuebles en el futuro.
   - **Implementación**:
     - Clases involucradas: `InmuebleFactory`, `CasaFactory`, `DepartamentoFactory`, `LocalFactory`, `CampoFactory`.
     - La clase `InmuebleService` utiliza las fábricas para crear instancias de inmuebles basadas en el tipo seleccionado por el usuario.

   ```csharp
   public abstract class InmuebleFactory
   {
       public abstract Inmueble CrearInmueble(string ubicacion, string localidad, decimal precio, Dictionary<string, object> detalles);
   }
   ```

2. **Patrón Visitor**
   - **Descripción**: El patrón Visitor permite definir nuevas operaciones sobre los objetos sin cambiar sus clases. En este proyecto, se utiliza para realizar cálculos específicos sobre los inmuebles, como el cálculo de impuestos, boleto y costo total.
   - **Implementación**:
     - Interfaz `IVisitor` define las operaciones que pueden realizarse sobre los inmuebles.
     - Clases de visitantes: `CalculoImpuestoVisitor`, `CalculoBoletoVisitor`, `CalculoCostoTotalVisitor` implementan estas operaciones.
     - Las clases `Casa`, `Departamento`, `Local`, `Campo` implementan el método `Aceptar` que acepta un visitante y permite que la operación se ejecute en la instancia del inmueble.

   ```csharp
   public interface IVisitor
   {
       void Visit(Campo campo);
       void Visit(Casa casa);
       void Visit(Departamento departamento);
       void Visit(Local local);
   }
   ```

   ```csharp
   public class CalculoImpuestoVisitor : IVisitor
   {
       public decimal Importe { get; private set; }

       public void Visit(Campo campo)
       {
           Importe = campo.Precio * 0.10m;
       }

       public void Visit(Casa casa)
       {
           Importe = casa.Precio * 0.05m;
       }

       public void Visit(Departamento departamento)
       {
           Importe = departamento.Precio * 0.01m;
       }

       public void Visit(Local local)
       {
           Importe = local.Precio * 0.12m;
       }
   }
   ```

3. **Patrón Repository**
   - **Descripción**: El patrón Repository se utiliza en la capa DAL para gestionar el acceso a los datos de los inmuebles. El repositorio actúa como un intermediario entre la capa de lógica de negocio y la fuente de datos.
   - **Implementación**:
     - Clase `InmuebleRepository` simula un almacenamiento en memoria para los inmuebles vendidos.
     - La lógica de negocio no interactúa directamente con la fuente de datos, sino a través del repositorio.

   ```csharp
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
   ```

### Clases Principales

#### 1. **Clases en la Capa Domain**

- **Inmueble (abstracta)**
  - Propiedades: `Ubicacion`, `Localidad`, `Precio`, `FechaVenta`.
  - Método abstracto: `Aceptar(IVisitor visitor)`.

- **Casa, Departamento, Local, Campo**
  - Extienden `Inmueble`.
  - Implementan el método `Aceptar` para aceptar un visitante.

#### 2. **Clases en la Capa BLL**

- **InmuebleService**
  - Maneja la lógica de negocio para la venta de inmuebles.
  - Utiliza `InmuebleFactory` para crear instancias de inmuebles.
  - Utiliza visitantes (`CalculoImpuestoVisitor`, `CalculoBoletoVisitor`, `CalculoCostoTotalVisitor`) para calcular impuestos, boletos, y costos totales.

- **InmuebleFactory y sus subclases (CasaFactory, DepartamentoFactory, LocalFactory, CampoFactory)**
  - Encapsulan la lógica de creación de inmuebles.

- **Visitantes (CalculoImpuestoVisitor, CalculoBoletoVisitor, CalculoCostoTotalVisitor)**
  - Realizan operaciones específicas sobre los inmuebles.

#### 3. **Clases en la Capa DAL**

- **InmuebleRepository**
  - Simula un repositorio en memoria para el almacenamiento y la recuperación de inmuebles vendidos.

#### 4. **Clases en la Capa UI**

- **Program**
  - Interactúa con el usuario a través de la consola.
  - Permite la venta de inmuebles y la visualización de inmuebles vendidos.
  - Muestra detalles como el tipo de propiedad, ubicación, fecha de venta, cálculo de impuestos, boleto, y costo total.

### Ejemplo de Uso

1. **Vender un Inmueble:**
   - El usuario selecciona el tipo de inmueble que desea vender.
   - Se le solicitan detalles específicos del inmueble.
   - El inmueble se vende, y se calculan y muestran los detalles de la venta.

2. **Ver Inmuebles Vendidos:**
   - El usuario puede ver una lista de todos los inmuebles vendidos, junto con los cálculos de impuestos, boletos y costos totales.

### Conclusión

Este proyecto demuestra una implementación robusta de patrones de diseño en un contexto de gestión inmobiliaria. El uso de Factory, Visitor y Repository asegura un código organizado, flexible y fácil de mantener, que puede adaptarse fácilmente a cambios futuros o nuevas funcionalidades.
