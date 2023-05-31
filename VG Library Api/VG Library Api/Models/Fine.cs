using System;
using System.Collections.Generic;

namespace VG_Library_Api.Models;

public partial class Fine
{
    public int FineId { get; set; }

    public string? FineAmount { get; set; }

    public DateTime? FineDate { get; set; }

    public int BorrowId { get; set; }

    public int MemberId { get; set; }

    public virtual Borrow Borrow { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<Transcaction> Transcactions { get; } = new List<Transcaction>();
}
