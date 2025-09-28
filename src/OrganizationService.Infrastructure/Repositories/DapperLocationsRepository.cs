using OrganizationService.Application.Locations;
using OrganizationService.Domain.LocationManagement;
using OrganizationService.Infrastructure.Dapper;
using Dapper;
using CSharpFunctionalExtensions;
using OrganizationService.Domain.Common;

namespace OrganizationService.Infrastructure.Repositories
{
    public class DapperLocationsRepository : ILocationsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DapperLocationsRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<Result<Guid, ErrorList>> Add(Location location, CancellationToken cancellationToken = default)
        {
            try
            {
                using var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);

                const string locationInsertSql = """
                                             INSERT INTO Locations (id, name, timezone, addresses)
                                             VALUES (@Id, @Name, @Timezone, @Addresses)
                                             """;
                var locationParams = new
                {
                    Id = location.Id.Value,
                    Name = location.Name.Value,
                    Timezone = location.Timezone.Value,
                    Addresses = location.Addresses
                };

                await connection.ExecuteAsync(locationInsertSql, locationParams);

                return location.Id.Value;
            }
            catch (Exception)
            {
                return Errors.General.ValueIsInvalid().ToErrorList();
            }
        }
    }
}
