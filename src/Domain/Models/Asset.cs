namespace Domain.Models
{
    public class Asset
    {
        public Asset(int id, string name, int financialInstitutionId)
        {
            Id = id;
            Name = name;
            FinancialInstitutionId = financialInstitutionId;
        }

        public int Id { get; }
        public string Name { get; }
        public int FinancialInstitutionId { get; }
    }
}