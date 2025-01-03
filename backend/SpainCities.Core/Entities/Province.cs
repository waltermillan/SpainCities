using System;
using System.Collections.Generic;

namespace Core.Entities;

public class Province : BaseEntity
{
    public string Name { get; set; } = null!;

    public int RegionId { get; set; }
}
