using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_5.Entities;

[Table("Products")]
public class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public float ProductPrice { get; set; }
}