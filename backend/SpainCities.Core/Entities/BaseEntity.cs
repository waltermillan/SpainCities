using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class BaseEntity
{
    [Column("Id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;
}
