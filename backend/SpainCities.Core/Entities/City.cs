using System;
using System.Collections.Generic;

namespace Core.Entities;

public class City : BaseEntity
{
    public string Name { get; set; } = null!;

    public int ProvinceId{ get; set; }
    public int RegionId { get; set; }
}
