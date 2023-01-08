using System.Threading.Tasks;
using ExternalServices.Kinvo.Models;
using Refit;

namespace ExternalServices.Kinvo.Api
{
    internal interface IKinvoService
    {
        [Get("/portfolio-query/ProductConsolidation/getProducts/{portfolioId}")]
        Task<GetProductsResponse> GetProducts(long portfolioId);

        [Post("/portfolio-query/StatementConsolidation/GetPortfolioStatement")]
        Task<GetStatementResponse> GetStatement([Body]GetStatementRequest request);
    }
}