using System.ComponentModel.DataAnnotations.Schema;
using Assignment_2.Dependencies;

namespace Assignment_2.Models;

[Table("Trees")]
public class Tree : ITree
{
    public int TreeId { get; set; }
    public string? Name { get; set; }
    public string? Species { get; set; }
    public int? Height { get; set; }

    public void Grow()
    {
        Height += 2;
    }

}