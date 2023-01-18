using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Infra.Database.Postgres.Connection;
using Infra.Database.Postgres.Consts;

namespace Infra.Database.Postgres;

internal class PortfolioAllocationRepository : IPortfolioAllocationRepository
{
    private readonly DbConnection _dbConnection;

    public PortfolioAllocationRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<PortfolioAllocation> Add(PortfolioAllocation portfolioAllocation)
    {
        const string sql = $@"INSERT INTO {Tables.PortfolioAllocation} (DimensionId, AssetId, Percentage)
                                                        VALUES (@DimensionId, @AssetId, @Percentage)
                                                        RETURNING Id, DimensionId, AssetId, Percentage";

        var insertedRow = await _dbConnection.QuerySingle<PortfolioAllocation?>(sql, new
        {
            portfolioAllocation
        });

        if (insertedRow == null)
            throw new RepositoryException($"Error trying to insert portfolio allocation.");

        return insertedRow;
    }

    public async Task<IEnumerable<PortfolioAllocation>> GetAll()
    {
        const string sql = $@"SELECT Id, DimensionId, AssetId, Percentage
                                   FROM {Tables.PortfolioAllocation}";

        var portfolioAllocations = await _dbConnection.QueryAsync<PortfolioAllocation>(sql);

        if (portfolioAllocations == null)
            throw new RepositoryException($"Error trying to get portfolio allocation.");

        return portfolioAllocations;
    }

    public async Task<PortfolioAllocation> Get(int portfolioAllocationId)
    {
        const string sql = $@"SELECT Id, DimensionId, AssetId, Percentage
                                   FROM {Tables.PortfolioAllocation}
                                   WHERE Id = @portfolioAllocationId";

        var portfolioAllocation = await _dbConnection.QuerySingle<PortfolioAllocation?>(sql, new
        {
            portfolioAllocationId
        });

        if (portfolioAllocation == null)
            throw new RepositoryException($"Error trying to get portfolio allocation by id {portfolioAllocationId}.");

        return portfolioAllocation;
    }

    public async Task<PortfolioAllocation> UpdatePercentage(int portfolioAllocationId, decimal percentage)
    {
        const string sql = $@"UPDATE {Tables.PortfolioAllocation}
                                 SET Percentage = @percentage
                               WHERE Id = @portfolioAllocationId
                               RETURNING Id, DimensionId, AssetId, Percentage";

        var updatedRow = await _dbConnection.QuerySingle<PortfolioAllocation?>(sql, new
        {
            portfolioAllocationId,
            percentage
        });

        if (updatedRow == null)
            throw new RepositoryException($"Error trying to update portfolio allocation percentage.");

        return updatedRow;
    }
}