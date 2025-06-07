# MsFacturacion

Este repositorio contiene un microservicio de facturación desarrollado en .NET 8.

El servicio expone una API REST para la emisión de comprobantes de pago y forma parte de un sistema HIS más grande.

## Estructura del proyecto

- `src/MsFacturacion.Api`: Proyecto principal de ASP.NET Core Web API.

## Uso

Debido a las restricciones del entorno, no se incluye el binario de .NET. Para compilar y ejecutar el microservicio localmente se necesita tener instalado el SDK de .NET 8:

```bash
cd src/MsFacturacion.Api
# Restaurar y ejecutar
# dotnet run
```

Al ejecutarse, la API expone un endpoint de prueba:

```
GET /api/billing/test
```

que devuelve un mensaje de confirmación.
