using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Infra.Database.Postgres.Connection;

namespace Infra.Database.Postgres
{
    internal class FinancialInstitutionRepository : IFinancialInstitutionRepository
    {
        private readonly DbConnection _dbConnection;

        public FinancialInstitutionRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<FinancialInstitution> Add(FinancialInstitution financialInstitution)
        {
            const string sql = @"INSERT INTO FinancialInstitution (Name)
                                                        VALUES (@Name)
                                                        RETURNING Id, Name";

            var insertedRow = await _dbConnection.QuerySingle<FinancialInstitution>(sql, financialInstitution);

            if (insertedRow == null)
                throw new RepositoryException($"Error trying to insert financial institution.");

            return insertedRow;
        }
    }
}