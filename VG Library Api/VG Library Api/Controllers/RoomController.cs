using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;
using System.Security.Claims;
using VG_Library_Api.DTO;
using VG_Library_Api.Models;
using VG_Library_Api.Tools;

namespace VG_Library_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        //for database
        private readonly VglibraryContext _context;


        public RoomController(VglibraryContext context)
        {
            _context = context;
        }

        //booking a room 
        [HttpPost]
        [Route("bookroom")]
        public async Task <IActionResult> Bookroom([FromBody] RoomReserve room)
        {
              String urlsend ;
            try
            {
                int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("MemberID"));


                if (room == null)
                {
                    return BadRequest("You cant book empty room");
                }

                if (userID == null || userID <= 0)
                {
                    return BadRequest("You are not log in, Please log in");
                }

                var newborrow = new Room();

                newborrow.MemberId = userID;
                //newborrow.BookId = brk.BookId;
                newborrow.RoomName = room.RoomName;
                newborrow.RoomType = room.RoomType;
                newborrow.RoomUrl = UrlBorrow();
                newborrow.RoomDate = room.RoomDate;
                newborrow.RoomStatus = "InActive";
                newborrow.RoomAvailability = "Available";
                urlsend = newborrow.RoomUrl;


                _context.Rooms.Add(newborrow);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    message = "Present the url to Admin for confimation",
                    urlToken = urlsend
                });

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Creating a url for the Room booking
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


        //get all rooms
        [HttpGet]
        [Route("getallrooms")]
        public async Task<IActionResult> GetRooms()
        {

            try
            {
                var rooms = _context.Rooms.Select(x => new {
                    x.RoomId,
                    x.RoomName,
                    x.RoomType,
                    x.RoomStatus,
                    x.RoomDate,
                    x.RoomUrl,
                    x.RoomAvailability,
                    name = x.Member.MemberName,
                    surname = x.Member.MemberSurname,
                    email = x.Member.MemberEmail
                }).ToList();

                if (rooms != null)
                {
                    return Ok(rooms);
                }
                return BadRequest("There are no rooms in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //get room booked by the url 
        [HttpGet]
        [Route("getroombyurl")]
        public async Task<IActionResult> getroom(string url)
        {
            try
            {
                var check = _context.Rooms.Where(u => u.RoomUrl == url).FirstOrDefault();
                if (check != null)
                {
                    return Ok(check);
                }
                else
                {
                     


                    

                    return BadRequest( "No information for this url");


                }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
