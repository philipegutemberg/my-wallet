namespace ProviderManagement.Entities
{
    internal record AssetPositionProvider
    {
        public int AssetId { get; set; }
        public int ProviderId { get; set; }
        public string ProviderExternalId { get; set; } = "";
    }
}