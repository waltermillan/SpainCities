using System;
using System.Collections.Generic;

namespace Core.Entities;

public class Region : BaseEntity
{
    public string Name { get; set; } = null!;
    public int Population { get; set; }
    public string Capital { get; set; }
    public int Surface { get; set; }
}
