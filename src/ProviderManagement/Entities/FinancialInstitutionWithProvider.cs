using Domain.Entities;
using ProviderManagement.Enums;
using ProviderManagement.Models;

namespace ProviderManagement.Entities
{
    public class FinancialInstitutionWithProvider : FinancialInstitution, IModelWithProvider
    {
        public FinancialInstitutionWithProvider(int id, string name, EnumProvider providerId, string externalIdOnProvider)
            : base(id, name)
        {
            ProviderId = providerId;
            ExternalIdOnProvider = externalIdOnProvider;
        }

        public FinancialInstitutionWithProvider(string name, EnumProvider providerId, string externalIdOnProvider)
            : base(name)
        {
            ProviderId = providerId;
            ExternalIdOnProvider = externalIdOnProvider;
        }

        public EnumProvider ProviderId { get; }
        public string ExternalIdOnProvider { get; }
    }
}