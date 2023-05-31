using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VG_Library_Api.DTO;
using VG_Library_Api.Models;
using VG_Library_Api.Tools;

namespace VG_Library_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //enable cors
    [EnableCors("appCors")]
    public class MembersController : ControllerBase
    {
        //for database connection
        private readonly VglibraryContext _context;

        private readonly IConfiguration _configuration;

        public MembersController(VglibraryContext _context, IConfiguration _configuration)
        {
            this._context = _context;
            this._configuration = _configuration;
        }

        //Register Member
        [HttpPost]
        [Route("memberregister")]
        public async Task<IActionResult> Memberregister([FromBody] MemberRegister memb)
        {
            try
            {
                var user = _context.Members.Where(u => u.MemberEmail== memb.MemberEmail).FirstOrDefault();
                if (user != null)
                {
                    return BadRequest("Member has already Register");
                }
                else
                {
                    user = new Member();

                    user.MemberName = memb.MemberName;
                    user.MemberSurname = memb.MemberSurname;
                    user.MemberEmail = memb.MemberEmail;
                    user.MemberContactDetails = memb.MemberContactDetails;
                    user.MemberAddress = memb.MemberAddress;
                    user.MemberPassword= Password.hashPassword(memb.MemberPassword);
                    user.MemberStatus = "InActive";
                    user.MemberBlock = "Block";
                    user.MemberDateCreate = DateTime.Now;


                    _context.Members.Add(user);
                    await _context.SaveChangesAsync();

                    return Ok(new { message = "Successful registered a Member" });


                }


            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //for creating the jwt token
        private JwtSecurityToken getToken(List<Claim> authClaim)
        {

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken
            (
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        //Login for Member 
        [HttpPost]
        [Route("memberlogin")]
        public async Task<IActionResult> Citizenlogin([FromBody] MemberLogin user)
        {
            try
            {
                String password = Password.hashPassword(user.MemberPassword);
                var user11 = _context.Members.Where(u => u.MemberEmail == user.MemberEmail && u.MemberPassword == password ).FirstOrDefault();
                if (user11 == null)
                {
                    return BadRequest("Either email or password is incorrect!!");
                }
                else
                {
                    List<Claim> authClaim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user11.MemberEmail),
                        new Claim ("MemberID",user11.MemberId.ToString())
                    };

                    var token = this.getToken(authClaim);

                    return Ok(new
                    {
                        message = "Member login in the system",
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });

                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //Get all  members
        [HttpGet]
        [Route("getallmembers")]
        public async Task<IActionResult> getallmembers()
        {

            try
            {
                List<Member> listuser = _context.Members.ToList();
                if (listuser != null)
                {
                    return Ok(listuser);
                }
                return Ok("They are no Members in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        //Get all Members by dscending order and status is active
        [HttpGet]
        [Route("getmembersStatus")]
        public async Task<IActionResult> getallMembersDescending()
        {

            try
            {
                List<Member> listuser = _context.Members.Where(u => u.MemberStatus == "InActive").OrderByDescending(t => t.MemberId).ToList();
                if (listuser != null)
                {
                    return Ok(listuser);
                }
                return Ok("They are no Members in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Get all Members by dscending order and Block status is Blocked
        [HttpGet]
        [Route("getmembersBlock")]
        public async Task<IActionResult> getallMembersBlocked()
        {

            try
            {
                List<Member> listuser = _context.Members.Where(u => u.MemberBlock == "Block").OrderByDescending(t => t.MemberId).ToList();
                if (listuser != null)
                {
                    return Ok(listuser);
                }
                return Ok("They are no Members in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        //get Member  by an ID
        [HttpGet]
        [Route("memberby/{id}")]
        public async Task<IActionResult> getmemberid(int id)
        {

            var user11 = _context.Members.Select(t => new
            {
                t.MemberId,
                t.MemberName,
                t.MemberSurname,
                t.MemberEmail,
                t.MemberContactDetails,
                t.MemberAddress,
                t.MemberStatus,
                t.MemberBlock,
                t.MemberDateCreate

            }).Where(u => u.MemberId == id).FirstOrDefault();

            if (user11 == null)
            {
                return BadRequest("Cant find the specific member");

            }

            return Ok(user11);


        }


        //Getting current loged member in the system
        [HttpGet]
        [Route("member/current")]
        public async Task<IActionResult> getcurrentmember()
        {
            int id = Convert.ToInt32(HttpContext.User.FindFirstValue("MemberID"));

            if (id == null || id <= 0)
            {
                return BadRequest("You are not log in");
            }
            var user11 = _context.Members.Select(t => new
            {
                t.MemberId,
                t.MemberName,
                t.MemberSurname,
                t.MemberEmail,
                t.MemberContactDetails,
                t.MemberAddress,
                t.MemberStatus,
                t.MemberBlock,
                t.MemberDateCreate
            }).Where(u => u.MemberId == id).FirstOrDefault();

            return Ok(user11);


        }


        //Edit the Member profile
        [HttpPut]
        [Route("editmember/{id}")]
        public async Task<ActionResult> memberrupdate([FromBody] MemberUpdate user, int id)
        {
            int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("MemberID"));

            var dbu = await _context.Members.FindAsync(id);
            if (userID == null || userID <= 0)
            {
                return BadRequest("Yuu are not log in");
            }
            if (dbu == null)
            {
                return BadRequest("Member not found");
            }

            dbu.MemberName = user.MemberName;
            dbu.MemberSurname = user.MemberSurname;
            dbu.MemberContactDetails = user.MemberContactDetails;
            dbu.MemberAddress = user.MemberAddress;
         
            await _context.SaveChangesAsync();

            return Ok(new { message = "Member profile successful updated"} );
        }

        //delete specific Member
        [HttpDelete]
        [Route("deletemember/{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {

            var delm = await _context.Members.FindAsync(id);

            if (delm == null)
            {
                return BadRequest("Member not found");
            }

            _context.Members.Remove(delm);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Member has been deleted" });
        }



    }
}
