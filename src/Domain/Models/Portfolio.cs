using System.Collections.Generic;

namespace Domain.Models
{
    public record Portfolio
    {
        public Portfolio(IEnumerable<AssetPosition> assets)
        {
            Assets = assets;
        }

        public IEnumerable<AssetPosition> Assets { get; }
    }
}