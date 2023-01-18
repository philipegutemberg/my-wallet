using Domain.Exceptions;
using Infra.Database.Postgres.Connection;
using Infra.Database.Postgres.Consts;
using ProviderManagement.Entities;
using ProviderManagement.Repositories;

namespace Infra.Database.Postgres
{
    internal class ProviderAssetRepository : IProviderAssetRepository
    {
        private readonly DbConnection _dbConnection;

        public ProviderAssetRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task Add(SyncableAssetWithProvider assetWithProvider)
        {
            const string sql = $@"INSERT INTO {Tables.ProviderAsset} (AssetId, ProviderId, ExternalIdOnProvider)
                                                            VALUES (@AssetId, @ProviderId, @ExternalIdOnProvider)";

            var insertedRow = await _dbConnection.ExecuteAsyncWithTransaction(sql, new
            {
                AssetId = assetWithProvider.Id,
                assetWithProvider.ProviderId,
                assetWithProvider.ExternalIdOnProvider
            });

            if (insertedRow == 0)
                throw new RepositoryException($"Error trying to insert provider asset.");
        }

        public async Task<IEnumerable<SyncableAssetWithProvider>> GetAll()
        {
            const string sql = $@"SELECT A.Id, A.Name, A.FinancialInstitutionId, PA.ProviderId, PA.ExternalIdOnProvider
                                    FROM {Tables.ProviderAsset} PA JOIN {Tables.Asset} A
                                                            ON PA.AssetId = A.Id";

            return await _dbConnection.QueryAsync<SyncableAssetWithProvider>(sql);
        }
    }
}