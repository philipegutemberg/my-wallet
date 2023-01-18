using Domain.Entities;

namespace Domain.Repositories;

public interface IPortfolioDimensionRepository
{
    Task<PortfolioDimension> Add(PortfolioDimension portfolioDimension);

    Task<IEnumerable<PortfolioDimension>> GetAll();

    Task<PortfolioDimension> Get(int dimensionId);

    Task<PortfolioDimension> AssignParent(int dimensionId, int parentDimensionId);
}