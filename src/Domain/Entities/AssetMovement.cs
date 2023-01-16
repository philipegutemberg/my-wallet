using System;
using Domain.Enums;

namespace Domain.Entities
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
            decimal totalInvested
        ) : this(externalId, assetId, date, type, price, count, totalInvested)
        {
            Id = id;
        }

        public AssetMovement(
            string externalId,
            int assetId,
            DateTime date,
            EnumMovementType type,
            decimal price,
            decimal count,
            decimal totalInvested)
        {
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