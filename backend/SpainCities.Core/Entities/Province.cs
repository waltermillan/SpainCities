using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Provinces")]
public class Province : BaseEntity
{
    [Column("region_id")]
    public int RegionId { get; set; }
}
