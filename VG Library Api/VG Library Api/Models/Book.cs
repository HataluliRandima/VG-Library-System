using System;
using System.Collections.Generic;

namespace VG_Library_Api.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string BookTitle { get; set; } = null!;

    public string BookAuthor { get; set; } = null!;

    public string? BookStatus { get; set; }

    public string? BookFine { get; set; }

    public string? BookOrdered { get; set; }

    public int? BookQuantity { get; set; }

    public int BcId { get; set; }

    public virtual BookCategory Bc { get; set; } = null!;

    public virtual ICollection<Borrow> Borrows { get; } = new List<Borrow>();
}
