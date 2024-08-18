## Modelado de un Negocio Inmobiliario

### Tipos de Propiedades

La inmobiliaria cuenta con diferentes ventas, las cuales corresponden a:

- **Campos**:
  - **Características**:
    - Ubicación
    - Hectáreas
    - Localidad
    - Precio
    - Electricidad
    - Forestada

- **Casas**:
  - **Características**:
    - Ubicación
    - Localidad
    - Precio
    - Cantidad de ambientes
    - Antigüedad

- **Departamentos**:
  - **Características**:
    - Ubicación
    - Localidad
    - Precio
    - Cantidad de ambientes
    - Antigüedad
    - Departamentos por piso

- **Locales**:
  - **Características**:
    - Ubicación
    - Localidad
    - Precio
    - Superficie total
    - Superficie cubierta

### Cálculos Necesarios para la Venta

- **Cálculo de Impuestos**:
  - **Campos**: 10% del precio de la propiedad.
  - **Casas**: 5% del precio de la propiedad.
  - **Departamentos**: 1% del precio de la propiedad.
  - **Locales**: 12% del precio de la propiedad.

- **Cálculo de Boleto**:
  - Para **Campos, Casas, Departamentos y Locales**: 10% del precio del inmueble.

- **Costo Total de la Propiedad**:
  - **Campos y Casas**: Precio de la propiedad más el boleto de compra más los impuestos.
  - **Departamentos y Locales**: Precio de la propiedad más el boleto de compra más los impuestos. Al total anterior restarle un 5%.

### Resolver

1. **Diagrama de Clases Propuesto**.
2. **Implementación en C#**: Puede ser una aplicación de consola o WinForms, según su preferencia.
3. **Mostrar por Pantalla la Siguiente Información**:
   - Tipo de Propiedad
   - Ubicación
   - Fecha de Venta
   - Cálculo de Impuesto: `[Importe del cálculo de impuesto]`
   - Cálculo de Boleto: `[Importe del cálculo de boleto]`
   - Cálculo de Propiedad: `[Importe del cálculo de propiedad]`

**Nota**: Resolver utilizando los conceptos de la **POO** y las buenas prácticas de programación.

### Casos de Prueba

| Tipo de Propiedad | Valor Propiedad | Total Boleto | Total Impuesto | Total $ Propiedad |
|-------------------|-----------------|--------------|----------------|-------------------|
| Campo             | 1.500.000       | 150.000      | 150.000        | 1.800.000         |
| Casa              | 425.000         | 42.500       | 21.250         | 488.750           |
| Departamento      | 152.000         | 15.200       | 1.520          | 160.284           |
| Local             | 600.000         | 60.000       | 72.000         | 695.400           |

