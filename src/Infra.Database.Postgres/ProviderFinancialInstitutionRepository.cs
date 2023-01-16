using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Exceptions;
using Infra.Database.Postgres.Connection;
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

        public async Task Add(FinancialInstitutionWithProvider financialInstitutionWithProvider)
        {
            const string sql = @"INSERT INTO ProviderFinancialInstitution (FinancialInstitutionId, ProviderId, ExternalIdOnProvider)
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

        public async Task<IEnumerable<FinancialInstitutionWithProvider>> GetAll()
        {
            const string sql = @"SELECT FI.Id, FI.Name, PFI.ProviderId, PFI.ExternalIdOnProvider
                                    FROM ProviderFinancialInstitution PFI JOIN FinancialInstitution FI
                                                                            ON PFI.FinancialInstitutionId = FI.Id";

            return await _dbConnection.QueryAsync<FinancialInstitutionWithProvider>(sql);
        }
    }
}