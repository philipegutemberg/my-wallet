namespace Domain.Entities;

public class AssetDimension
{
    public AssetDimension(int id, string name, int? parentId = null)
        : this(name, parentId)
    {
        Id = id;
    }

    public AssetDimension(string name, int? parentId = null)
    {
        Name = name;
        ParentId = parentId;
    }

    public int Id { get; }
    public string Name { get; }
    public int? ParentId { get; }

    public bool IsRoot() => !ParentId.HasValue;
}