using System;
using System.Collections.Generic;

namespace VG_Library_Api.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomName { get; set; } = null!;

    public string? RoomType { get; set; }

    public string? RoomStatus { get; set; }

    public string? RoomUrl { get; set; }

    public int MemberId { get; set; }

    public DateTime? RoomDate { get; set; }

    public string? RoomAvailability { get; set; }

    public virtual Member Member { get; set; } = null!;
}
