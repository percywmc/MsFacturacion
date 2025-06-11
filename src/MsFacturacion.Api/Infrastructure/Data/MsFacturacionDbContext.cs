using Microsoft.EntityFrameworkCore;
using MsFacturacion.Api.Domain.Entities;

namespace MsFacturacion.Api.Infrastructure.Data;

public class MsFacturacionDbContext : DbContext
{
    public MsFacturacionDbContext(DbContextOptions<MsFacturacionDbContext> options) : base(options)
    {
    }

    public DbSet<Comprobante> Comprobantes => Set<Comprobante>();
    public DbSet<DetalleComprobante> Detalles => Set<DetalleComprobante>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Emisor> Emisores => Set<Emisor>();
    public DbSet<FormaPago> FormasPago => Set<FormaPago>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Comprobante>().ToTable("Comprobante");
        modelBuilder.Entity<DetalleComprobante>().ToTable("DetalleComprobante");
        modelBuilder.Entity<Cliente>().ToTable("Cliente");
        modelBuilder.Entity<Emisor>().ToTable("Emisor");
        modelBuilder.Entity<FormaPago>().ToTable("FormaPago");
    }
}
