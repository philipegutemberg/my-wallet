using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Infra.Database.Postgres.Connection;

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
            const string sql = @"INSERT INTO AssetPosition (AssetId, FinancialPosition, AppliedValue, Profitability, PortfolioPercentage)
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
            const string sql = @"SELECT *
                                   FROM AssetPosition
                                  WHERE AssetId = @assetId";

            var assetPositionRow = await _dbConnection.QuerySingle<AssetPosition>(sql, new
            {
                assetId
            });

            if (assetPositionRow == null)
                throw new RepositoryException($"Error trying to get asset position.");

            return assetPositionRow;
        }
    }
}