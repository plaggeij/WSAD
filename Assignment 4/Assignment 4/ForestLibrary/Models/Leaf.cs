namespace ForestLibrary;

public class Leaf
{
    public int LeafId { get; set; }
    public string Name { get; set; }

    public int BranchId { get; set; }
    public Branch Branch { get; set; }
}