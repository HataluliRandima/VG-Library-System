using VG_Library_Api.Models;

namespace VG_Library_Api.DTO
{
    public class AddFine
    {
    //    public int FineId { get; set; }

        public string? FineAmount { get; set; }

        //public DateTime? FineDate { get; set; }

        public int BorrowId { get; set; }

       public int MemberId { get; set; }

     //   public virtual Borrow Borrow { get; set; } = null!;
        //
       // public virtual Member Member { get; set; } = null!;

       // public virtual ICollection<Transcaction> Transcactions { get; } = new List<Transcaction>();

    }
}
