using Domain.Entities;
using ProviderManagement.Enums;
using ProviderManagement.Models;
using ProviderManagement.Sync.Interfaces;

namespace ProviderManagement.Entities
{
    public class SyncableFinancialInstitutionWithProvider : FinancialInstitution, IModelWithProvider, ISyncableEntity
    {
        public SyncableFinancialInstitutionWithProvider(int id, string name, int providerId, string externalIdOnProvider)
            : base(id, name)
        {
            ProviderId = (EnumProvider)providerId;
            ExternalIdOnProvider = externalIdOnProvider;
        }

        public SyncableFinancialInstitutionWithProvider(string name, EnumProvider providerId, string externalIdOnProvider)
            : base(name)
        {
            ProviderId = providerId;
            ExternalIdOnProvider = externalIdOnProvider;
        }

        public EnumProvider ProviderId { get; }
        public string ExternalIdOnProvider { get; }

        public string GetSyncId() => ExternalIdOnProvider;
    }
}