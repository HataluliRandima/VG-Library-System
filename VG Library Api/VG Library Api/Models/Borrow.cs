using System;
using System.Collections.Generic;

namespace VG_Library_Api.Models;

public partial class Borrow
{
    public int BorrowId { get; set; }

    public DateTime? BorrowDate { get; set; }

    public DateTime? BorrowReturnDate { get; set; }

    public string? BorrowUrl { get; set; }

    public string? BorrowUrlscanner { get; set; }

    public string? BorrowStatus { get; set; }

    public int BookId { get; set; }

    public int MemberId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<Fine> Fines { get; } = new List<Fine>();

    public virtual Member Member { get; set; } = null!;
}
