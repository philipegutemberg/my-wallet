using System;
using Domain.Entities;
using Domain.Enums;
using ProviderManagement.Enums;

namespace ProviderManagement.Models
{
    internal record ProviderAssetMovement
    {
        public EnumProvider ProviderId { get; init; }
        public string Id { get; init; } = "";
        public string AssetPositionId { get; init; } = "";
        public DateTime Date { get; init; }
        public EnumMovementType Type { get; init; }
        public decimal Price { get; init; }
        public decimal Count { get; init; }
        public decimal TotalAmount { get; init; }
    }
}