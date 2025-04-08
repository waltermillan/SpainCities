﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Regions")]
public class Region : BaseEntity
{
    [Column("name")]
    public string Name { get; set; } = null!;
    [Column("population")]
    public int Population { get; set; }
    [Column("capital")] 
    public string Capital { get; set; }
    [Column("Surface")]    
    public int Surface { get; set; }
}
