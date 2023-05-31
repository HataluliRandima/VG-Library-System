using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG_Library_Api.DTO;
using VG_Library_Api.Models;

namespace VG_Library_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FineController : ControllerBase
    {

        // for database connection
        private readonly VglibraryContext _context;

        public FineController (VglibraryContext context)
        {
            _context = context;
        }

        //for issueing a fine to a specific member on book they borrowed
        [HttpPost]
        [Route("addfine")]
        public async Task<IActionResult> addfinetomember([FromBody] AddFine fine)
        {
            try
            {
                if (fine == null)
                {
                    return BadRequest("You cant request empty fine");
                }

               

                var newfine = new Fine();

                newfine.MemberId = fine.MemberId;
                newfine.BorrowId = fine.BorrowId;
                newfine.FineAmount = fine.FineAmount;
                newfine.FineDate = DateTime.Now;
             



                _context.Fines.Add(newfine);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    message = "Succesful added a fine to the member" 
                });

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get all fines for those members 
        [HttpGet]
        [Route("getallfines")]
        public async Task<IActionResult> getAllFInes()
        {

            try
            {
                var brr = _context.Fines.Select(t => new
                {
                    t.BorrowId,
                    t.FineDate,
                    t.FineAmount,
                    t.FineId,
                    bookname = t.Borrow.Book.BookTitle,
                    bookauthor = t.Borrow.Book.BookAuthor,
                    borrowurl = t.Borrow.BorrowUrl,
                    name = t.Member.MemberName,
                    surname = t.Member.MemberSurname

                }).ToList();
                if (brr != null)
                {
                    return Ok(brr);
                }

                return BadRequest("The are no Fines here");

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
