using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Infra.Database.Postgres.Connection;

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
            const string sql = @"INSERT INTO Asset (Name, FinancialInstitutionId)
                                                        VALUES (@Name, @FinancialInstitutionId)
                                                        RETURNING Id, Name, FinancialInstitutionId";

            var insertedRow = await _dbConnection.QuerySingle<Asset>(sql, asset);

            if (insertedRow == null)
                throw new RepositoryException($"Error trying to insert asset.");

            return insertedRow;
        }
    }
}