using Dapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Infra.Database.Postgres.Connection;
using Infra.Database.Postgres.Consts;

namespace Infra.Database.Postgres;

internal class AssetDimensionRepository : IAssetDimensionRepository
{
    private readonly DbConnection _dbConnection;

    public AssetDimensionRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<AssetDimension> Add(AssetDimension assetDimension)
    {
        const string sql = $@"INSERT INTO {Tables.Dimension} (Name, ParentId)
                                                        VALUES (@Name, @ParentId)
                                                        RETURNING Id, Name, ParentId";

        var insertedRow = await _dbConnection.QuerySingle<AssetDimension?>(sql, new
        {
            assetDimension
        });

        if (insertedRow == null)
            throw new RepositoryException($"Error trying to insert dimension.");

        return insertedRow;
    }

    public async Task<IEnumerable<AssetDimension>> GetAll()
    {
        const string sql = $@"SELECT Id, Name, ParentId
                                   FROM {Tables.Dimension}";

        var dimensions = await _dbConnection.QueryAsync<AssetDimension>(sql);

        if (dimensions == null)
            throw new RepositoryException($"Error trying to get dimensions.");

        return dimensions;
    }

    public async Task<AssetDimension> Get(int dimensionId)
    {
        const string sql = $@"SELECT Id, Name, ParentId
                                   FROM {Tables.Dimension}
                                   WHERE Id = @dimensionId";

        var dimension = await _dbConnection.QuerySingle<AssetDimension?>(sql, new
        {
            dimensionId
        });

        if (dimension == null)
            throw new RepositoryException($"Error trying to get dimension by id {dimensionId}.");

        return dimension;
    }

    public async Task<AssetDimension> AssignParent(int dimensionId, int parentDimensionId)
    {
        const string sql = $@"UPDATE {Tables.Dimension}
                                 SET ParentId = @parentDimensionId
                               WHERE Id = @dimensionId
                               RETURNING Id, Name, ParentId";

        var updatedRow = await _dbConnection.QuerySingle<AssetDimension?>(sql, new
        {
            dimensionId,
            parentDimensionId
        });

        if (updatedRow == null)
            throw new RepositoryException($"Error trying to assign parent dimension to dimension.");

        return updatedRow;
    }
}