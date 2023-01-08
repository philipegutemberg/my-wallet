using System;
using System.Security.AccessControl;

namespace ExternalServices.Kinvo.Models
{
    internal record GetStatementResponse : KinvoBaseResponse<GetStatementResponse.Movement[]>
    {
        public record Movement
        {
            public long Id { get; init; }
            public int RecordType { get; init; }
            public long PortfolioProductId { get; init; }
            public int ProductTypeId { get; init; }
            public DateTime Date { get; init; }
            public int? MovementType { get; init; }
            public int? EventType { get; init; }
            public decimal Value { get; init; }
            public decimal Amount { get; init; }
            public decimal Equity { get; init; }
            public int FinancialInstitutionId { get; init; }

            public bool IsMovement() => MovementType is not null && EventType is null;

            public bool IsEvent() => EventType is not null && MovementType is null;
        }
    }
}