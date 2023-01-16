using ProviderManagement.Enums;
using ProviderManagement.Models;

namespace ExternalServices.Kinvo.Models
{
    internal record GetProductsResponse : KinvoBaseResponse<GetProductsResponse.Product[]>
    {
        public class Product
        {
            public long PositionId { get; set; }
            public long ProductId { get; init; }
            public string ProductName { get; init; } = "";
            public int FinancialInstitutionId { get; init; }
            public string FinancialInstitutionName { get; init; } = "";
            public decimal ValueApplied { get; init; }
            public decimal Equity { get; init; }
            public decimal Profitability { get; init; }
            public decimal PortfolioPercentage { get; init; }
            public bool HasBalance { get; init; }
            public string StrategyOfDiversificationDescription { get; init; } = "";

            public ProviderAssetPosition ToProviderAssetPosition() =>
                new()
                {
                    ProviderId = EnumProvider.Kinvo,
                    Id = PositionId.ToString(),
                    AssetId = ProductId.ToString(),
                    AssetName = ProductName,
                    Profitability = Profitability,
                    AppliedValue = ValueApplied,
                    FinancialPosition = Equity,
                    PortfolioPercentage = PortfolioPercentage,
                    FinancialInstitutionId = FinancialInstitutionId.ToString(),
                    FinancialInstitutionName = FinancialInstitutionName
                };
        }
    }
}