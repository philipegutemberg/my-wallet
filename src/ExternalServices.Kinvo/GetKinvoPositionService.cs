using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using ExternalServices.Kinvo.Api;
using ExternalServices.Kinvo.Models;
using ProviderManagement.Models;
using ProviderManagement.Providers;
using AssetPosition = ProviderManagement.Models.AssetPosition;

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

        public async Task<IEnumerable<AssetPosition>> GetPositions()
        {
            GetProductsResponse response = await _kinvoService.GetProducts(PORTFOLIOID);

            return response.GetResponse().Select(p => new AssetPosition
            {
                Id = p.PortfolioProductId.ToString(),
                AssetId = p.ProductId.ToString(),
                AssetName = p.ProductName,
                Profitability = p.Profitability,
                AppliedValue = p.ValueApplied,
                FinancialPosition = p.Equity,
                PortfolioPercentage = p.PortfolioPercentage,
                FinancialInstitutionId = p.FinancialInstitutionId.ToString(),
                FinancialInstitutionName = p.FinancialInstitutionName
            });
        }

        public async Task<IEnumerable<AssetMovement>> GetMovements()
        {
            GetStatementResponse response = await _kinvoService.GetStatement(new GetStatementRequest
            {
              Fetch = 1000000,
              Offset = 0,
              PortfolioId = PORTFOLIOID
            });

            return response.GetResponse().Where(p => p.IsMovement()).Select(p => new AssetMovement
            {
                Count = p.Amount,
                Date = p.Date,
                Id = p.Id.ToString(),
                Price = p.Value,
                Type = (EnumMovementType)p.MovementType!,
                TotalAmount = p.Equity,
                AssetPositionId = p.PortfolioProductId.ToString()
            });
        }

        public async Task<IEnumerable<AssetEvent>> GetEvents()
        {
            GetStatementResponse response = await _kinvoService.GetStatement(new GetStatementRequest
            {
                Fetch = 1000000,
                Offset = 0,
                PortfolioId = PORTFOLIOID
            });

            return response.GetResponse().Where(p => p.IsEvent()).Select(p => new AssetEvent
            {
                Count = p.Amount,
                Date = p.Date,
                Id = p.Id.ToString(),
                Value = p.Value,
                Type = (EnumEventType)p.MovementType!,
                TotalAmount = p.Equity,
                AssetPositionId = p.PortfolioProductId.ToString()
            });
        }
    }
}