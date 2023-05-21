using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_2.Models;

[Table("Trees")]
public class Tree
{
    public int TreeId { get; set; }
    public string? Name { get; set; }
    public string? Species { get; set; }
    
}