using System;
using Domain.Enums;

namespace Domain.Models
{
    public class AssetEvent
    {
        public AssetEvent(long id, string externalId, int assetId, DateTime date, EnumEventType type, decimal value, decimal count, decimal totalAmount)
        {
            Id = id;
            ExternalId = externalId;
            AssetId = assetId;
            Date = date;
            Type = type;
            Value = value;
            Count = count;
            TotalAmount = totalAmount;
        }

        public long Id { get; }
        public string ExternalId { get; }
        public int AssetId { get; }
        public DateTime Date { get; }
        public EnumEventType Type { get; }
        public decimal Value { get; }
        public decimal Count { get; }
        public decimal TotalAmount { get; }
    }
}