using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VG_Library_Api.DTO;
using VG_Library_Api.Models;

namespace VG_Library_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        //for database connection
        private readonly VglibraryContext _context;

        public TransactionController(VglibraryContext _context)
        {
            this._context = _context;
        }

        //paying fine by the member 
        [HttpPost]
        [Route("addpayment")]
        public async Task<IActionResult> addpayment([FromBody] AddTransaction trans)
        {
            try
            {
                int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("MemberID"));


                if (trans == null)
                {
                    return BadRequest("You cant pay empty fine");
                }

                if (userID == null || userID <= 0)
                {
                    return BadRequest("You are not log in, Please log in");
                }

                var newpay = new Transcaction();

                newpay.MemberId = userID;
                newpay.TranscPayment = trans.TranscPayment;
                newpay.TranscDate =  DateTime.Now;
                newpay.TranscStatus = "UnVerified";
                newpay.FineId = trans.FineId;
                

                _context.Transcactions.Add(newpay);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    message = "Successful paid the fine"
                    
                });



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        //view all the payments done 
        [HttpGet]
        [Route("getallpayments")]
        public async Task<IActionResult> getallpayments()
        {
            try
            {
                var brr = _context.Transcactions.Select(t => new
                {
                    t.TranscId,
                    t.TranscPayment,
                    t.TranscStatus,
                    t.FineId,
                    bookname = t.Fine.Borrow.Book.BookTitle,
                    bookauthor = t.Fine.Borrow.Book.BookAuthor,
                    borrowurl = t.Fine.Borrow.BorrowUrl,
                    name = t.Member.MemberName,
                    surname = t.Member.MemberSurname,
                    finedate = t.Fine.FineDate

                }).ToList();
                if (brr != null)
                {
                    return Ok(brr);
                }

                return BadRequest("The are no Transactions here");

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
