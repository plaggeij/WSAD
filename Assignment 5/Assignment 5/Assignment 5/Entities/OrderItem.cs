using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment_5.Entities;

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