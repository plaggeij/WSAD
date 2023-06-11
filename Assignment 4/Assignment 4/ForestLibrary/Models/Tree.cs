using System.ComponentModel.DataAnnotations.Schema;

namespace ForestLibrary;

[Table("Trees")]
public class Tree
{
    public int TreeId { get; set; }
    public string? Name { get; set; }
    public string? Species { get; set; }
    public int? Height { get; set; }
    
    public ICollection<Branch>? Branches { get; set; }
}