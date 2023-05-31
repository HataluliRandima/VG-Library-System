using System;
using System.Collections.Generic;

namespace VG_Library_Api.Models;

public partial class Transcaction
{
    public int TranscId { get; set; }

    public DateTime? TranscDate { get; set; }

    public string? TranscPayment { get; set; }

    public string? TranscStatus { get; set; }

    public int MemberId { get; set; }

    public int FineId { get; set; }

    public virtual Fine Fine { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
