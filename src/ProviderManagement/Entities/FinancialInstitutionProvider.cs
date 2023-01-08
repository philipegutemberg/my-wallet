namespace ProviderManagement.Entities
{
    internal record FinancialInstitutionProvider
    {
        public int AssetId { get; set; }
        public int ProviderId { get; set; }
        public string ProviderExternalId { get; set; } = "";
    }
}