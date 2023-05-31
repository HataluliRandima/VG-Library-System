using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG_Library_Api.DTO;
using VG_Library_Api.Models;

namespace VG_Library_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        //connecting to the database

        private readonly VglibraryContext _context;

        public NotificationController(VglibraryContext context)
        {
            _context = context;
        }

        //Sending notification to the Member of the vg library

        [HttpPost]
        [Route("sendnotification")]
        public async Task<IActionResult> SendNotification([FromBody] NotificationAdd noti)
        {
            try
            {
                if(noti == null)
                {
                    return BadRequest("you cant send empty notification ");
                }

                var addnt = new Notification();

                addnt.NotificationType = noti.NotificationType;
                addnt.NotificationDetails= noti.NotificationDetails;
                addnt.NotificationStatus = "Sent";
                addnt.NotificationDate= DateTime.Now;
                addnt.MemberId = noti.MemberId;

                _context.Notifications.Add(addnt);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Successful sent a notification to a member" });

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get all notifications 
        [HttpGet]
        [Route("getallnotifiation")]
        public async Task<IActionResult> GetNotifications()
        {

            try
            {
                var notifications = _context.Notifications.Select(x => new {
                x.NotificationId,
                x.NotificationType,
                x.NotificationDetails,
                x.NotificationStatus,
                x.NotificationDate,
                name = x.Member.MemberName,
                surname = x.Member.MemberSurname,
                email = x.Member.MemberEmail
                }).ToList();

                if(notifications != null)
                {
                    return Ok(notifications);
                }
                return BadRequest("There are no notifications in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
