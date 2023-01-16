using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using ProviderManagement.Entities;
using ProviderManagement.Models;
using ProviderManagement.Repositories;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Sync
{
    internal class ProviderSyncFinancialInstitutionService : IProviderSyncFinancialInstitutionService
    {
        private readonly IProviderFinancialInstitutionRepository _providerFinancialInstitutionRepository;
        private readonly IFinancialInstitutionRepository _financialInstitutionRepository;

        public ProviderSyncFinancialInstitutionService(
            IProviderFinancialInstitutionRepository providerFinancialInstitutionRepository,
            IFinancialInstitutionRepository financialInstitutionRepository)
        {
            _providerFinancialInstitutionRepository = providerFinancialInstitutionRepository;
            _financialInstitutionRepository = financialInstitutionRepository;
        }

        public async Task<IEnumerable<FinancialInstitutionWithProvider>> SyncFinancialInstitutions(IEnumerable<ProviderAssetPosition> positions)
        {
            IEnumerable<FinancialInstitutionWithProvider> returnedInstitutions = GetReturnedFinancialInstitutions(positions);

            IEnumerable<FinancialInstitutionWithProvider> savedProviderInstitutions =
                await _providerFinancialInstitutionRepository.GetAll();

            IEnumerable<FinancialInstitutionWithProvider> toBeInserted =
                returnedInstitutions.Where(i =>
                    savedProviderInstitutions.All(spi => spi.ExternalIdOnProvider != i.ExternalIdOnProvider));

            return await Insert(toBeInserted);
        }

        private async Task<IEnumerable<FinancialInstitutionWithProvider>> Insert(IEnumerable<FinancialInstitutionWithProvider> financialInstitutionWithProviders) =>
            await Task.WhenAll(financialInstitutionWithProviders.Select(Insert));

        private async Task<FinancialInstitutionWithProvider> Insert(FinancialInstitutionWithProvider financialInstitutionWithProvider)
        {
            FinancialInstitution inserted = await _financialInstitutionRepository.Add(financialInstitutionWithProvider);
            financialInstitutionWithProvider.AssignId(inserted.Id);

            await _providerFinancialInstitutionRepository.Add(new FinancialInstitutionWithProvider(
                inserted.Id,
                financialInstitutionWithProvider.Name,
                financialInstitutionWithProvider.ProviderId,
                financialInstitutionWithProvider.ExternalIdOnProvider
            ));

            return financialInstitutionWithProvider;
        }

        private IEnumerable<FinancialInstitutionWithProvider> GetReturnedFinancialInstitutions(IEnumerable<ProviderAssetPosition> positions) =>
            positions
                .Select(p => new FinancialInstitutionWithProvider(p.FinancialInstitutionName, p.ProviderId, p.FinancialInstitutionId))
                .DistinctBy(r => r.ExternalIdOnProvider);
    }
}