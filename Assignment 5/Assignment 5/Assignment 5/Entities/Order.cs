using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_5.Entities;

[Table("Orders")]
public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
}