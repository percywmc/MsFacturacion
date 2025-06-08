using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using MsFacturacion.Api.Application;
using MsFacturacion.Api.Domain;

namespace MsFacturacion.Api.Infrastructure;

/// <summary>
/// Implementación de <see cref="IComprobanteRepository"/> usando SQL Server.
/// </summary>
public class SqlServerComprobanteRepository : IComprobanteRepository
{
    private readonly string _connectionString;

    public SqlServerComprobanteRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    public void Add(Comprobante comprobante)
    {
        using var connection = CreateConnection();
        const string sql = @"INSERT INTO Comprobantes
                             (Id, Tipo, RucEmisor, RazonSocialEmisor, Monto, FechaEmision)
                             VALUES (@Id, @Tipo, @RucEmisor, @RazonSocialEmisor, @Monto, @FechaEmision)";
        connection.Execute(sql, comprobante);
    }

    public Comprobante? GetById(Guid id)
    {
        using var connection = CreateConnection();
        const string sql = @"SELECT Id, Tipo, RucEmisor, RazonSocialEmisor, Monto, FechaEmision
                             FROM Comprobantes WHERE Id = @Id";
        return connection.QueryFirstOrDefault<Comprobante>(sql, new { Id = id });
    }
}

