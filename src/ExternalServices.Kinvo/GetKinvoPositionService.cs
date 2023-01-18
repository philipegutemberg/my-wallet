using ExternalServices.Kinvo.Api;
using ExternalServices.Kinvo.Models;
using ProviderManagement.Models;
using ProviderManagement.Providers;

namespace ExternalServices.Kinvo
{
    internal class GetKinvoPositionService : IKinvoProviderService
    {
        private const long PORTFOLIOID = 536142;

        private readonly IKinvoService _kinvoService;

        public GetKinvoPositionService(IKinvoService kinvoService)
        {
            _kinvoService = kinvoService;
        }

        public async Task<IEnumerable<ProviderAssetPosition>> GetPositions()
        {
            GetProductsResponse response = await _kinvoService.GetProducts(PORTFOLIOID);

            return response.GetResponse().Select(p => p.ToProviderAssetPosition());
        }

        public async Task<IEnumerable<ProviderAssetMovement>> GetMovements()
        {
            GetStatementResponse response = await _kinvoService.GetStatement(new GetStatementRequest
            {
              Fetch = 1000000,
              Offset = 0,
              PortfolioId = PORTFOLIOID
            });

            return response.GetResponse().Where(p => p.IsMovement()).Select(p => p.ToProviderAssetMovement());
        }

        public async Task<IEnumerable<ProviderAssetEvent>> GetEvents()
        {
            GetStatementResponse response = await _kinvoService.GetStatement(new GetStatementRequest
            {
                Fetch = 1000000,
                Offset = 0,
                PortfolioId = PORTFOLIOID
            });

            return response.GetResponse().Where(p => p.IsEvent()).Select(p => p.ToProviderAssetEvent());
        }
    }
}