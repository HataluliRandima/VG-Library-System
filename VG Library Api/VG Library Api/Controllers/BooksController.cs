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
    public class BooksController : ControllerBase
    {

        //for database connection
        private readonly VglibraryContext _context;

        public BooksController(VglibraryContext context)
        {
            _context = context;
        }

        //Adding the book or inserting it 

        [HttpPost]
        [Route("addBook")]
        public async Task<IActionResult> AddBook([FromBody] AddBook book)
        {
            try {
                var booko = _context.Books.Where(u => u.BookTitle == book.BookTitle ).FirstOrDefault();
                if (booko != null)
                {
                    return BadRequest("This Book has already been Registered!!!");
                }
                else
                {
                    booko = new Book();

                    booko.BookTitle = book.BookTitle;
                    booko.BookAuthor = book.BookAuthor;
                    booko.BookQuantity = book.BookQuantity;
                    booko.BookFine = book.BookFine;
                    booko.BookStatus = "Available";
                    booko.BookStatus = "Active";
                    booko.BcId = book.BcId;

                     _context.Books.Add(booko);
                    await _context.SaveChangesAsync();

                    return Ok(new { message = "Successful added a book" });


                }


            }
            catch(Exception ex)
            {
                    return BadRequest(ex.Message);
            }

        }

        //get all books
        [HttpGet]
        [Route("allbooks")]
        public async Task<IActionResult> getaalbooks()
        {
            try
            {
                var books = _context.Books.Select(t => new
                {
                    t.BookAuthor,
                    t.BookId,
                    t.BookTitle,
                    t.BookFine,
                    t.BookStatus,
                    t.BookQuantity,
                    t.BookOrdered,
                    category  = t.Bc. BcCategory,
                    subcategory = t.Bc.BcSubCategory
                } ).ToList();
                if (books != null)
                {
                    return Ok(books);
                }
                return BadRequest("There are no books in the database");


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //get all numbers of books
        [HttpGet]
        [Route("bookgnumbers")]
        public async Task<IActionResult> getActiveRequestsnumbers()
        {

            try
            {
                

                var quolist = _context.Books.Select(t => new
                {
                    t.BookAuthor,
                    t.BookId,
                    t.BookTitle,
                    t.BookFine,
                    t.BookStatus,
                    t.BookQuantity,
                    t.BookOrdered,
                    category = t.Bc.BcCategory,
                    subcategory = t.Bc.BcSubCategory
                }).ToList();

                return Ok(quolist.Count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get a book by an id to see all other information
        [HttpGet]
        [Route("getbook/{id}")]
        public async Task<IActionResult> getbookid(int id)
        {

            var user11 = _context.Books.Select(t => new
            {
                t.BookAuthor,
                t.BookId,
                t.BookTitle,
                t.BookFine,
                t.BookStatus,
                t.BookQuantity,
                t.BookOrdered,
                category = t.Bc.BcCategory,
                subcategory = t.Bc.BcSubCategory

            }).Where(u => u.BookId == id).FirstOrDefault();

            if (user11 == null)
            {
                return BadRequest("Cant find the specific book");

            }

            return Ok(user11);


        }
    }
}
