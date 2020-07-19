using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;

        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        [Route("GetUserProfile")]
        public async Task<Object> GetUSerProfile()
        {
            //DigitalBoardMarkerContext db = new DigitalBoardMarkerContext();
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            //int tempId = db.Users.Where(u => u.Email == user.Email).FirstOrDefault().Id;
            //user.Id = Convert.ToString(tempId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }
    }
}