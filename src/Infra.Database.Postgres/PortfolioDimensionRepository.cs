using Dapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Infra.Database.Postgres.Connection;
using Infra.Database.Postgres.Consts;

namespace Infra.Database.Postgres;

internal class PortfolioDimensionRepository : IPortfolioDimensionRepository
{
    private readonly DbConnection _dbConnection;

    public PortfolioDimensionRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<PortfolioDimension> Add(PortfolioDimension portfolioDimension)
    {
        const string sql = $@"INSERT INTO {Tables.PortfolioDimension} (Name, ParentId)
                                                        VALUES (@Name, @ParentId)
                                                        RETURNING Id, Name, ParentId";

        var insertedRow = await _dbConnection.QuerySingle<PortfolioDimension?>(sql, new
        {
            portfolioDimension
        });

        if (insertedRow == null)
            throw new RepositoryException($"Error trying to insert dimension.");

        return insertedRow;
    }

    public async Task<IEnumerable<PortfolioDimension>> GetAll()
    {
        const string sql = $@"SELECT Id, Name, ParentId
                                   FROM {Tables.PortfolioDimension}";

        var dimensions = await _dbConnection.QueryAsync<PortfolioDimension>(sql);

        if (dimensions == null)
            throw new RepositoryException($"Error trying to get dimensions.");

        return dimensions;
    }

    public async Task<PortfolioDimension> Get(int dimensionId)
    {
        const string sql = $@"SELECT Id, Name, ParentId
                                   FROM {Tables.PortfolioDimension}
                                   WHERE Id = @dimensionId";

        var dimension = await _dbConnection.QuerySingle<PortfolioDimension?>(sql, new
        {
            dimensionId
        });

        if (dimension == null)
            throw new RepositoryException($"Error trying to get dimension by id {dimensionId}.");

        return dimension;
    }

    public async Task<PortfolioDimension> AssignParent(int dimensionId, int parentDimensionId)
    {
        const string sql = $@"UPDATE {Tables.PortfolioDimension}
                                 SET ParentId = @parentDimensionId
                               WHERE Id = @dimensionId
                               RETURNING Id, Name, ParentId";

        var updatedRow = await _dbConnection.QuerySingle<PortfolioDimension?>(sql, new
        {
            dimensionId,
            parentDimensionId
        });

        if (updatedRow == null)
            throw new RepositoryException($"Error trying to assign parent dimension to dimension.");

        return updatedRow;
    }
}