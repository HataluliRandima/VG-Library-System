using System;
using System.Collections.Generic;

namespace VG_Library_Api.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string MemberName { get; set; } = null!;

    public string MemberSurname { get; set; } = null!;

    public string MemberEmail { get; set; } = null!;

    public string MemberPassword { get; set; } = null!;

    public string MemberAddress { get; set; } = null!;

    public string MemberContactDetails { get; set; } = null!;

    public string? MemberStatus { get; set; }

    public string? MemberBlock { get; set; }

    public DateTime? MemberDateCreate { get; set; }

    public virtual ICollection<Borrow> Borrows { get; } = new List<Borrow>();

    public virtual ICollection<Fine> Fines { get; } = new List<Fine>();

    public virtual ICollection<Notification> Notifications { get; } = new List<Notification>();

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();

    public virtual ICollection<Transcaction> Transcactions { get; } = new List<Transcaction>();
}
