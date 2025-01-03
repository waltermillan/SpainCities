using System;
using System.Collections.Generic;

namespace Core.Entities;

public class Image : BaseEntity
{
    public int RegionId { get; set; }

    public string ImageBase64 { get; set; }
    public string Name { get; set; }
}
