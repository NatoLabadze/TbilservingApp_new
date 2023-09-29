using Core.Application;
using Core.Application.DTOs.UsersDTO;
using Core.Application.Interfaces.Repository;
using Core.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TbilservingApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TbilservingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly UserServices userServices;

        public AuthController(UserServices userServices)
        {


            this.userServices = userServices;
        }

        [AllowAnonymous]
        [HttpPost("logIn")]


        public async Task<IActionResult> LogIn([FromQuery] string UserName, [FromQuery] string Password)
        {

            var user = await userServices.ValidateUser(UserName, Password);


            if (user == null)
                return BadRequest("იუზერი ან პაროლი არასწორია");

            var token = JwtValidationExtensions.GenerateJwtToken(
                user.Id.ToString(),
                user.UserName,
                user.FirstName,
                user.LastName
                );

            Response.Headers.Add("AccessToken", token);
            return Ok(user);


        }
        [AllowAnonymous]
        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            await userServices.AddUser(userDTO);
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("confirmSignUp")]
        public async Task<IActionResult> SignUpConfirm([FromBody] SignUpSmsConfirmRequest request)
        {
            var user = await userServices.SignUpSmsConfirm(request);

            var token = JwtValidationExtensions.GenerateJwtToken(
            user.Id.ToString(),
             user.UserName,
            user.FirstName,
            user.LastName
            );

            Response.Headers.Add("AccessToken", token);

            return Ok("sms კოდი დადასტურდა");
        }
    }
}
