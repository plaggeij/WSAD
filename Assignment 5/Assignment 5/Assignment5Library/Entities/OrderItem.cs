using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment5Library.Entities;

[Table("OrderLineItems")]
[PrimaryKey("OrderLineItemId")]
public class OrderItem
{
    public int OrderLineItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
}