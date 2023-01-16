using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAssetRepository
    {
        Task<Asset> Add(Asset asset);
    }
}