using System;
using Domain.Enums;

namespace Domain.Models
{
    public class AssetMovement
    {
        public AssetMovement(
            long id,
            string externalId,
            int assetId,
            DateTime date,
            EnumMovementType type,
            decimal price,
            decimal count,
            decimal totalInvested)
        {
            Id = id;
            ExternalId = externalId;
            AssetId = assetId;
            Date = date;
            Type = type;
            Price = price;
            Count = count;
            TotalAmount = totalInvested;
        }

        public long Id { get; }
        public string ExternalId { get; }
        public int AssetId { get; }
        public DateTime Date { get; }
        public EnumMovementType Type { get; }
        public decimal Price { get; }
        public decimal Count { get; }
        public decimal TotalAmount { get; }
    }
}