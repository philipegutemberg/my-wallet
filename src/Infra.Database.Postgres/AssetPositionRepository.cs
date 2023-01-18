using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Infra.Database.Postgres.Connection;
using Infra.Database.Postgres.Consts;

namespace Infra.Database.Postgres
{
    internal class AssetPositionRepository : IAssetPositionRepository
    {
        private readonly DbConnection _dbConnection;

        public AssetPositionRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<AssetPosition> Add(AssetPosition assetPosition)
        {
            const string sql = $@"INSERT INTO {Tables.AssetPosition} (AssetId, FinancialPosition, AppliedValue, Profitability, PortfolioPercentage)
                                                        VALUES (@AssetId, @FinancialPosition, @AppliedValue, @Profitability, @PortfolioPercentage)
                                                        RETURNING AssetId";

            var insertedRowId = await _dbConnection.QuerySingle<int?>(sql, new
            {
                AssetId = assetPosition.Asset.Id,
                assetPosition.FinancialPosition,
                assetPosition.AppliedValue,
                assetPosition.Profitability,
                assetPosition.PortfolioPercentage
            });

            if (!insertedRowId.HasValue)
                throw new RepositoryException($"Error trying to insert asset position.");

            return await Get(insertedRowId.Value);
        }

        public async Task<AssetPosition> Get(int assetId)
        {
            const string sql = $@"SELECT A.Id AS AssetId, A.Name As AssetName, A.PortfolioDimensionId, A.FinancialInstitutionId, AP.FinancialPosition, AP.AppliedValue, AP.Profitability, AP.PortfolioPercentage
                                   FROM {Tables.AssetPosition} AP JOIN {Tables.Asset} A
                                                                    ON AP.AssetId = A.Id
                                  WHERE A.Id = @assetId";

            var assetPositionRow = await _dbConnection.QuerySingle<AssetPosition>(sql, new
            {
                assetId
            });

            if (assetPositionRow == null)
                throw new RepositoryException($"Error trying to get asset position.");

            return assetPositionRow;
        }

        public async Task<IEnumerable<AssetPosition>> GetAll()
        {
            const string sql = $@"SELECT A.Id AS AssetId, A.Name As AssetName, A.PortfolioDimensionId, A.FinancialInstitutionId, AP.FinancialPosition, AP.AppliedValue, AP.Profitability, AP.PortfolioPercentage
                                   FROM {Tables.AssetPosition} AP JOIN {Tables.Asset} A
                                                                    ON AP.AssetId = A.Id";

            var assetsPositions = await _dbConnection.QueryAsync<AssetPosition>(sql);

            if (assetsPositions == null)
                throw new RepositoryException($"Error trying to get assets positions.");

            return assetsPositions;
        }

        public async Task RemoveAll()
        {
            const string sql = $@"DELETE FROM {Tables.AssetPosition}";

            await _dbConnection.ExecuteAsyncWithTransaction(sql);
        }
    }
}