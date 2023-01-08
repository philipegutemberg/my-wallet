using System;
using Domain.Enums;

namespace ProviderManagement.Models
{
    internal record AssetMovement
    {
        public string Id { get; init; } = "";
        public string AssetPositionId { get; init; } = "";
        public DateTime Date { get; init; }
        public EnumMovementType Type { get; init; }
        public decimal Price { get; init; }
        public decimal Count { get; init; }
        public decimal TotalAmount { get; init; }
    }
}