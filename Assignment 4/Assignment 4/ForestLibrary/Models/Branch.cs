using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForestLibrary.Models;

[Table("Branches")]
public class Branch
{
    [DisplayName("Branch ID")]
    public int BranchId { get; set; }
    [DisplayName("Name")]
    public string? Name { get; set; }
    [DisplayName("Type")]
    public string? Type { get; set; }
    
    public int TreeId { get; set; }
    public Tree? Tree { get; set; }

    public ICollection<Leaf>? Leaves { get; set; }
}