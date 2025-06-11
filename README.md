# MsFacturacion

Plantilla de API en .NET 8 con una estructura de tres capas:

- **Domain**: entidades y contratos.
- **Application**: servicios de aplicación.
- **Infrastructure**: implementaciones de infraestructura.

La API expone endpoints para administrar comprobantes electrónicos y un endpoint de prueba.

## Uso

```bash
cd src/MsFacturacion.Api
dotnet run
```

La cadena de conexión a SQL Server se encuentra en `appsettings.json` bajo `DefaultConnection`.
