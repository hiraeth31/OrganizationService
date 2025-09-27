using System.Data;

namespace OrganizationService.Infrastructure.Dapper
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default);
    }
}
