using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VG_Library_Api.DTO;
using VG_Library_Api.Models;
using VG_Library_Api.Tools;

namespace VG_Library_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //enable cors
    [EnableCors("appCors")]
    public class BookCategoryController : ControllerBase
    {
        //for database connection
        private readonly VglibraryContext _context;

        public BookCategoryController(VglibraryContext context)
        {
            _context = context;
        }

        //adding category and subcategory
        [HttpPost]
        [Route("addCategory")]
        public async Task<IActionResult> addCategorySub([FromBody] CategoryAdding cat)
        {
            try
            {
                if(cat == null)
                {
                    return BadRequest("you cant add empty category");
                }

                var categ = _context.BookCategories.Where(u => u.BcCategory == cat.BcCategory && u.BcSubCategory == cat.BcCategory).FirstOrDefault();
                if (categ != null)
                {
                    return BadRequest("Category has already Register");
                }
                else
                {
                    categ = new BookCategory();

                    categ.BcCategory = cat.BcCategory;
                    categ.BcSubCategory = cat.BcSubCategory;
                    
                    _context.BookCategories.Add(categ);
                    await _context.SaveChangesAsync();

                    return Ok(new { message = "Successful added a book category" });


                }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //get all categories
        [HttpGet]
        [Route("getallcategories")]
        public async Task<IActionResult> getCategories()
        {
            try
            {
                List<BookCategory> bc = _context.BookCategories.ToList();
                if(bc != null)
                {
                    return Ok(bc);
                }
                return BadRequest("There are no categories in the database");


            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
