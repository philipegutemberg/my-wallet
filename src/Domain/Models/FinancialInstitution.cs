namespace Domain.Models
{
    public class FinancialInstitution
    {
        public FinancialInstitution(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}