using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForestLibrary.Models;

[Table("Forests")]
public class Forest
{
    [DisplayName("Forest ID")]
    public int ForestId { get; set; }
    [DisplayName("Name")]
    public string? Name { get; set; }
    [DisplayName("Location")]
    public string? Location { get; set; }

    public ICollection<Tree>? Trees { get; set; }
}