# MsFacturacion

Este repositorio contiene un microservicio de facturación desarrollado en .NET 8.

El servicio expone una API REST para la emisión de comprobantes de pago y forma parte de un sistema HIS más grande. Se implementa siguiendo los principios de arquitectura limpia y el patrón CQRS.

La capa de infraestructura puede utilizar **SQL Server** como base de datos gracias a Dapper. Si no se configura la cadena de conexión, el servicio emplea un repositorio en memoria.

## Estructura del proyecto

- `src/MsFacturacion.Api`: Proyecto principal de ASP.NET Core Web API.

## Uso

Debido a las restricciones del entorno, no se incluye el binario de .NET. Para compilar y ejecutar el microservicio localmente se necesita tener instalado el SDK de .NET 8:

```bash
cd src/MsFacturacion.Api
# Restaurar y ejecutar
# dotnet run
```

Al ejecutarse, la API expone un endpoint de prueba y el endpoint para emitir comprobantes de pago:

```
GET /api/billing/test

POST /api/billing/comprobantes
```

El primero devuelve un mensaje de confirmación y el segundo permite registrar un nuevo comprobante.

### Configuración de la base de datos

1. Crear una base de datos llamada `MsFacturacion` en SQL Server y ejecutar el script `sql/create_comprobantes_table.sql` incluido en este repositorio.
2. Modificar la cadena de conexión `ConnectionStrings:DefaultConnection` en `appsettings.json` con los datos de tu servidor.

Si la cadena no se establece, el microservicio almacenará los comprobantes solo en memoria.

### Validaciones

La API valida los datos de entrada:

- El RUC del emisor debe contener 11 dígitos.
- La razón social es obligatoria y tiene un máximo de 100 caracteres.
- El monto debe ser mayor a cero.

