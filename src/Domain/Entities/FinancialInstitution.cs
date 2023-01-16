namespace Domain.Entities
{
    public class FinancialInstitution
    {
        public FinancialInstitution(int id, string name)
            : this(name)
        {
            Id = id;
        }

        public FinancialInstitution(string name)
        {
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; }

        public void AssignId(int id) => Id = id;
    }
}