using System;
using System.Collections.Generic;

namespace LibraryManagement.GUI.Entities;

public partial class Book
{
    public int BookId { get; set; }

    public string BookName { get; set; } = null!;

    public DateTime? PublicationDate { get; set; }

    public double? Price { get; set; }

    public string? Author { get; set; }

    public int BookCategoryId { get; set; }
}
