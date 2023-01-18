namespace Domain.Entities;

public class PortfolioDimension
{
    public PortfolioDimension(int id, string name, int? parentId = null)
        : this(name, parentId)
    {
        Id = id;
    }

    public PortfolioDimension(string name, int? parentId = null)
    {
        Name = name;
        ParentId = parentId;
    }

    public int Id { get; }
    public string Name { get; }
    public int? ParentId { get; }

    public bool IsRoot() => !ParentId.HasValue;
}