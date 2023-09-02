using EventHub.BL.Abstract;
using EventHub.Entities.DTOs;
using EventHub.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPut]
        [Authorize(Roles ="User")]
        public IActionResult PasswordUpdate(UserToUpdateDto userToUpdateDto)
        {
            var result = userService.GetById(userToUpdateDto.UserID);
            if (result.Data.Password == userToUpdateDto.Password) 
            {
                var user = new User
                {
                    UserID = userToUpdateDto.UserID,
                    FirstName = result.Data.FirstName,
                    LastName = result.Data.LastName,
                    Email = result.Data.Email,
                    Password = userToUpdateDto.NewPassword
                };
                var data = userService.Update(user);

                return Ok(data);
            }

            return BadRequest("Parola yanlış");
        }
    }
}
