using Microsoft.Extensions.DependencyInjection;

namespace Infra.Database.Postgres.Injection
{
    public static class PostgresInjector
    {
        public static IServiceCollection InjectPostgresServices(this IServiceCollection services) => services;
    }
}