using System;
using Domain.Enums;

namespace ProviderManagement.Models
{
    internal record AssetEvent
    {
        public string Id { get; init; } = "";
        public string AssetPositionId { get; init; } = "";
        public DateTime Date { get; init; }
        public EnumEventType Type { get; init; }
        public decimal Value { get; init; }
        public decimal Count { get; init; }
        public decimal TotalAmount { get; init; }
    }
}