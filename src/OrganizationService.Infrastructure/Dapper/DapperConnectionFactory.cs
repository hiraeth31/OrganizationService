﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Data;

namespace OrganizationService.Infrastructure.Dapper
{
    public class DapperConnectionFactory : IDisposable, IAsyncDisposable, IDbConnectionFactory
    {
        private const string DATABASE = "Database";
        private readonly NpgsqlDataSource _dataSource;

        public DapperConnectionFactory(IConfiguration configuration)
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration.GetConnectionString(DATABASE));
            dataSourceBuilder.UseLoggerFactory(CreateLoggerFactory());

            _dataSource = dataSourceBuilder.Build();
        }

        public async Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default)
        {
            return await _dataSource.OpenConnectionAsync(cancellationToken);
        }

        public void Dispose()
        {
            _dataSource.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _dataSource.DisposeAsync();
        }

        private ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}
