using Domain.Exceptions;
using Infra.Database.Postgres.Connection;
using Infra.Database.Postgres.Consts;
using ProviderManagement.Entities;
using ProviderManagement.Repositories;

namespace Infra.Database.Postgres
{
    internal class ProviderFinancialInstitutionRepository : IProviderFinancialInstitutionRepository
    {
        private readonly DbConnection _dbConnection;

        public ProviderFinancialInstitutionRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task Add(SyncableFinancialInstitutionWithProvider financialInstitutionWithProvider)
        {
            const string sql = $@"INSERT INTO {Tables.ProviderFinancialInstitution} (FinancialInstitutionId, ProviderId, ExternalIdOnProvider)
                                                                            VALUES (@FinancialInstitutionId, @ProviderId, @ExternalIdOnProvider)";

            var insertedRow = await _dbConnection.ExecuteAsyncWithTransaction(sql, new
            {
                FinancialInstitutionId = financialInstitutionWithProvider.Id,
                financialInstitutionWithProvider.ProviderId,
                financialInstitutionWithProvider.ExternalIdOnProvider
            });

            if (insertedRow == 0)
                throw new RepositoryException($"Error trying to insert provider financial institution.");
        }

        public async Task<IEnumerable<SyncableFinancialInstitutionWithProvider>> GetAll()
        {
            const string sql = $@"SELECT FI.Id, FI.Name, PFI.ProviderId, PFI.ExternalIdOnProvider
                                    FROM {Tables.ProviderFinancialInstitution} PFI JOIN {Tables.FinancialInstitution} FI
                                                                            ON PFI.FinancialInstitutionId = FI.Id";

            return await _dbConnection.QueryAsync<SyncableFinancialInstitutionWithProvider>(sql);
        }
    }
}