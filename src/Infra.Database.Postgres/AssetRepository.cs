using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Infra.Database.Postgres.Connection;
using Infra.Database.Postgres.Consts;

namespace Infra.Database.Postgres
{
    internal class AssetRepository : IAssetRepository
    {
        private readonly DbConnection _dbConnection;

        public AssetRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Asset> Add(Asset asset)
        {
            const string sql = $@"INSERT INTO {Tables.Asset} (Name, FinancialInstitutionId, PortfolioDimensionId)
                                                        VALUES (@Name, @FinancialInstitutionId, @PortfolioDimensionId)
                                                        RETURNING Id, Name, FinancialInstitutionId, PortfolioDimensionId";

            var insertedRow = await _dbConnection.QuerySingle<Asset>(sql, asset);

            if (insertedRow == null)
                throw new RepositoryException($"Error trying to insert asset.");

            return insertedRow;
        }

        public async Task<IEnumerable<Asset>> GetAll()
        {
            const string sql = $@"SELECT Id, Name, FinancialInstitutionId, PortfolioDimensionId
                                   FROM {Tables.Asset}";

            var assets = await _dbConnection.QueryAsync<Asset>(sql);

            if (assets == null)
                throw new RepositoryException($"Error trying to get assets.");

            return assets;
        }

        public async Task<Asset> AssignPortfolioDimension(int assetId, int portfolioDimensionId)
        {
            const string sql = $@"UPDATE {Tables.Asset}
                                 SET PortfolioDimensionId = @portfolioDimensionId
                               WHERE Id = @assetId
                               RETURNING Id, Name, FinancialInstitutionId, PortfolioDimensionId";

            var updatedRow = await _dbConnection.QuerySingle<Asset?>(sql, new
            {
                assetId,
                portfolioDimensionId
            });

            if (updatedRow == null)
                throw new RepositoryException($"Error trying to assign portfolio dimension on asset.");

            return updatedRow;
        }
    }
}