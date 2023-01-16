using System;
using System.Security.AccessControl;
using Domain.Enums;
using ProviderManagement.Enums;
using ProviderManagement.Models;

namespace ExternalServices.Kinvo.Models
{
    internal record GetStatementResponse : KinvoBaseResponse<GetStatementResponse.Movement[]>
    {
        public record Movement
        {
            public long Id { get; init; }
            public int RecordType { get; init; }
            public long PortfolioProductId { get; init; }
            public int ProductTypeId { get; init; }
            public DateTime Date { get; init; }
            public int? MovementType { get; init; }
            public int? EventType { get; init; }
            public decimal Value { get; init; }
            public decimal Amount { get; init; }
            public decimal Equity { get; init; }
            public int FinancialInstitutionId { get; init; }

            public bool IsMovement() => MovementType is not null && EventType is null;

            public bool IsEvent() => EventType is not null && MovementType is null;

            public ProviderAssetMovement ToProviderAssetMovement() =>
                new()
                {
                    ProviderId = EnumProvider.Kinvo,
                    Count = Amount,
                    Date = Date,
                    Id = Id.ToString(),
                    Price = Value,
                    Type = (EnumMovementType)MovementType!,
                    TotalAmount = Equity,
                    AssetPositionId = PortfolioProductId.ToString()
                };

            public ProviderAssetEvent ToProviderAssetEvent() =>
                new()
                {
                    ProviderId = EnumProvider.Kinvo,
                    Count = Amount,
                    Date = Date,
                    Id = Id.ToString(),
                    Value = Value,
                    Type = (EnumEventType)MovementType!,
                    TotalAmount = Equity,
                    AssetPositionId = PortfolioProductId.ToString()
                };
        }
    }
}