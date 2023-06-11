using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForestLibrary;

[Table("Trees")]
public class Tree
{
    [DisplayName("Tree ID")]
    public int TreeId { get; set; }
    [DisplayName("Name")]
    public string? Name { get; set; }
    [DisplayName("Species")]
    public string? Species { get; set; }
    [DisplayName("Height")]
    public int? Height { get; set; }
    
    public ICollection<Branch>? Branches { get; set; }
}