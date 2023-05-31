using System;
using System.Collections.Generic;

namespace VG_Library_Api.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string NotificationType { get; set; } = null!;

    public string NotificationDetails { get; set; } = null!;

    public string? NotificationStatus { get; set; }

    public int MemberId { get; set; }

    public DateTime? NotificationDate { get; set; }

    public virtual Member Member { get; set; } = null!;
}
