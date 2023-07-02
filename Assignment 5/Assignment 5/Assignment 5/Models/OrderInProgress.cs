using Assignment5Library.Entities;

namespace Assignment_5.Models;

public class OrderInProgress
{
    public Customer Customer { get; set; }
    public List<Product> Products { get; set; }
    public Order? Order { get; set; }
}