using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForestLibrary.Models;

[Table("Leaves")]
public class Leaf
{
    [DisplayName("Leaf ID")]
    public int LeafId { get; set; }
    [DisplayName("Name")]
    public string? Name { get; set; }

    public int BranchId { get; set; }
    public Branch? Branch { get; set; }
}