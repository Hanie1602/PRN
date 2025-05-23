﻿using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? Quantity { get; set; }

    public virtual ProductOrder Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
