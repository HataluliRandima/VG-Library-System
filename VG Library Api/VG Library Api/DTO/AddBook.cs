using VG_Library_Api.Models;

namespace VG_Library_Api.DTO
{
    public class AddBook
    {
        public string BookTitle { get; set; } = null!;

        public string BookAuthor { get; set; } = null!;

        public string? BookStatus { get; set; }

        public string? BookFine { get; set; }

        public string? BookOrdered { get; set; }

        public int? BookQuantity { get; set; }

        public int BcId { get; set; }
    }
}
