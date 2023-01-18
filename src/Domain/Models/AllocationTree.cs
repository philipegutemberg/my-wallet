namespace Domain.Models;

public class AllocationTree
{
    public AllocationTree()
    {
        Child = new List<AllocationTree>();
    }

    public decimal CurrentFinancialPosition { get; set; }
    public AllocationTree? Parent { get; set; }
    public IEnumerable<AllocationTree> Child { get; set; }
}