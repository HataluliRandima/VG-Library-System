using System;
using System.Collections.Generic;

namespace VG_Library_Api.Models;

public partial class BookCategory
{
    public int BcId { get; set; }

    public string BcCategory { get; set; } = null!;

    public string BcSubCategory { get; set; } = null!;

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
