namespace Domain.Entities
{
    public class Asset
    {
        public Asset(int id, string name, int financialInstitutionId, int? portfolioDimensionId)
            : this(name, financialInstitutionId, portfolioDimensionId)
        {
            Id = id;
        }

        public Asset(string name, int financialInstitutionId, int? portfolioDimensionId)
        {
            Name = name;
            FinancialInstitutionId = financialInstitutionId;
            PortfolioDimensionId = portfolioDimensionId;
        }

        public int Id { get; protected set; }
        public string Name { get; }
        public int FinancialInstitutionId { get; }
        public int? PortfolioDimensionId { get; set; }
    }
}