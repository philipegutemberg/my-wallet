using Domain.Entities;

namespace Domain.Repositories;

public interface IPortfolioAllocationRepository
{
    Task<PortfolioAllocation> Add(PortfolioAllocation portfolioAllocation);

    Task<IEnumerable<PortfolioAllocation>> GetAll();

    Task<PortfolioAllocation> Get(int portfolioAllocationId);

    Task<PortfolioAllocation> UpdatePercentage(int portfolioAllocationId, decimal percentage);
}