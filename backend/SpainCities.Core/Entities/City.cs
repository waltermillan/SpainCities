using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Cities")]
public class City : BaseEntity
{
    [Column("province_id")]
    public int ProvinceId{ get; set; }
    [Column("region_id")]
    public int RegionId { get; set; }
}
