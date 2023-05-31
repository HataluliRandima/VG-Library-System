using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VG_Library_Api.DTO;
using VG_Library_Api.Models;

namespace VG_Library_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //enable cors
    [EnableCors("appCors")]
    public class BorrowController : ControllerBase
    {

        //for database connection
        private readonly VglibraryContext _context;

        public BorrowController(VglibraryContext context)
        {
            _context = context;
        }

        //Boorowing a book by a member 
        [HttpPost]
        [Route("borrowbook")]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowBook brk)
        {
            String urlsend;
            try
            {
                int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("MemberID"));


                if (brk == null)
                {
                    return BadRequest("You cant borrow empty book");
                }

                if (userID == null || userID <= 0)
                {
                    return BadRequest("You are not log in, Please log in");
                }

                var newborrow = new Borrow();

                newborrow.MemberId = userID;
                newborrow.BookId = brk.BookId;
                newborrow.BorrowDate = brk.BorrowDate;
                newborrow.BorrowReturnDate = brk.BorrowReturnDate;
                 newborrow.BorrowUrl = UrlBorrow();
                   newborrow.BorrowStatus = "InActive";
                urlsend = newborrow.BorrowUrl;



                _context.Borrows.Add(newborrow);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Present the url to Admin for confimation",
                    urlToken = urlsend });


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Creating a url for the borrowing of a book 
        private string UrlBorrow()
        {
            var newRandomUrl = string.Empty;
            Random rand = new Random();

            var boolflag = true;

            while (boolflag)
            {
                newRandomUrl = "";

                for (int a = 0; a < 2; a++)
                {
                    var randNum = rand.Next(1, 9);
                    var randChar = (char)rand.Next('a', 'z');
                    var randChar1 = (char)rand.Next('A', 'Z');

                    newRandomUrl += randChar1.ToString();
                    newRandomUrl += randChar.ToString();
                    newRandomUrl += randNum.ToString();
                }


                var isDuplicate = _context.Borrows.Any(a => a.BorrowUrl == newRandomUrl);

                if (!isDuplicate)
                {
                    boolflag = false;
                }


            }
            return newRandomUrl;
        }

        //get all the borrows of books by members

        [HttpGet]
        [Route("getallborrowes")]
        public async Task<IActionResult> GetallBorrows()
        {

            try
            {
                var brr = _context.Borrows.Select(t => new
                {
                    t.BorrowId,
                    t.BorrowDate,
                    t.BorrowReturnDate,
                    t.BorrowStatus,
                    t.BorrowUrl,
                    name = t.Member.MemberName,
                    surname = t.Member.MemberSurname

                }).ToList();
                if( brr != null )
                {
                    return Ok(brr);
                }

                return BadRequest("The are no orders here");


            }catch(Exception e)
            { 
              return BadRequest(e.Message);
            }


        }

        //get borrow booked by the url 
        [HttpGet]
        [Route("getborrowbyurl")]
        public async Task<IActionResult> getborrow(string url)
        {
            try
            {
                var check = _context.Borrows.Where(u => u.BorrowUrl == url).FirstOrDefault();
                if (check != null)
                {
                    return Ok(check);
                }
                else
                { 
                    return BadRequest("No information for this url");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get all request for books status its InActive


        [HttpGet]
        [Route("getborrowesstatus")]
        public async Task<IActionResult> GetallBorrowsstatus()
        {

            try
            {
                var brr = _context.Borrows.Select(t => new
                {
                    t.BorrowId,
                    t.BorrowDate,
                    t.BorrowReturnDate,
                    t.BorrowStatus,
                    t.BorrowUrl,
                    name = t.Member.MemberName,
                    surname = t.Member.MemberSurname

                }).Where( u => u.BorrowStatus=="InActive").ToList();
                if (brr != null)
                {
                    return Ok(brr);
                }

                return BadRequest("The are no orders here");


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        //get all the borrowes for the specific member who has logged on the system

        [HttpGet]
        [Route("getborrowbymember")]
        public async Task<IActionResult> getborrowbymember()
        {

            try
            {

                int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("MemberID"));

                if (userID <= 0 || userID == null)
                {
                    return BadRequest("you are not logged, Please log in");
                }

                var brwm = _context.Borrows.Select(t => new
                {
                    t.BorrowId,
                    t.BorrowDate,
                    t.BorrowReturnDate,
                    t.BorrowStatus,
                    t.BorrowUrl,
                    bookname = t.Book.BookAuthor,
                    booktitle = t.Book.BookTitle
                  

                }).ToList();
                if (brwm != null)
                {
                    return Ok(brwm);
                }

                return BadRequest("The are no orders here");


            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Edit the Boorow status to either accept or decline
        [HttpPut]
        [Route("editborrow/{id}")]
        public async Task<ActionResult> memberrupdate([FromBody] BorrowUpdate brk, int id)
        {
           

            var dbu = await _context.Borrows.FindAsync(id);
            
            if (dbu == null)
            {
                return BadRequest("Borrow details not found");
            }

            dbu.BorrowStatus = brk.BorrowStatus;
           
            await _context.SaveChangesAsync();

            return Ok(new { message = "Borrowing details  successful updated for the member" });
        }
    }
}
