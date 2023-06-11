using System.ComponentModel.DataAnnotations.Schema;

namespace ForestLibrary;

[Table("Branches")]
public class Branch
{
    public int BranchId { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    
    public int TreeId { get; set; }
    public Tree? Tree { get; set; }

    public ICollection<Leaf>? Leaves { get; set; }
}