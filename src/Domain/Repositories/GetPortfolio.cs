using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IPortfolioRepository
    {
        Task<Portfolio> Get();
    }
}