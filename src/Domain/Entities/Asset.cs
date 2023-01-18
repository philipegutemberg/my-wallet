namespace Domain.Entities
{
    public class Asset
    {
        public Asset(int id, string name, int financialInstitutionId)
            : this(name, financialInstitutionId)
        {
            Id = id;
        }

        public Asset(string name, int financialInstitutionId)
        {
            Name = name;
            FinancialInstitutionId = financialInstitutionId;
        }

        public int Id { get; protected set; }
        public string Name { get; }
        public int FinancialInstitutionId { get; }
    }
}