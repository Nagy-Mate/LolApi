using System.ComponentModel.DataAnnotations;

namespace LolApi.Core;

public class Champion
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Role { get; set; }
    public required string Lane { get; set; }
    public int Difficulty { get; set; }
    public int BlueEssence { get; set; }
    public required string DamageType { get; set; }
    public required List<string> Images { get; set; }
    public required string Description { get; set; }


}