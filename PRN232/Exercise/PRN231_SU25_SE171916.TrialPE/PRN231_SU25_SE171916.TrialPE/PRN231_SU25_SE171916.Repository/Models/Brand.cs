﻿using System.ComponentModel.DataAnnotations;

namespace PRN231_SU25_SE171916.Repositories.Models;

public partial class Brand
{
    [Key]
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public string? Country { get; set; }

    public int? FoundedYear { get; set; }

    public string? Website { get; set; }

    public virtual ICollection<Handbag> Handbags { get; set; } = new List<Handbag>();
}
