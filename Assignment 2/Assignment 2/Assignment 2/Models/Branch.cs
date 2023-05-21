using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_2.Models;

[Table("Branches")]
public class Branch
{
    public int BranchId { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
}