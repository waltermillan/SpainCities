using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Pictures")]
public class Picture : BaseEntity
{
    [Column("region_id")]
    public int RegionId { get; set; }
    [Column("image_base64")]
    public string ImageBase64 { get; set; }
}
