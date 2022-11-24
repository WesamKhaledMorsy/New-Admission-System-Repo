using Admission.DB;
using Admission.Model.DomainModel;
using Admission.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;
using Twilio.TwiML.Messaging;

namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IAuthService _authService;
        private readonly ISendGridClient _sendGridClient;
        private readonly IConfiguration _configuration;
        private SendGridMessage msg;

        public AuthController (UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IAuthService authService, ISendGridClient sendGridClient
            , IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _authService = authService;
           _sendGridClient= sendGridClient; 
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            var result = await _authService.Register(register);
          

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!result.IsAuthenticated)
            {
                return Ok(result);
            }

            if (register.UserName == "google")
            {

                return BadRequest("Google cannot be used as a user name");
            }

            //if (!register.Email.ToLower().EndsWith("@yahoo.com") || !register.Email.ToLower().EndsWith("@gmail.com"))
            //{
            //    return BadRequest("Only yahoo.com or gmail.com email addresses are allowed");
            //}
            return Ok(result);
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.Login(login);
            if (!result.IsAuthenticated)
            {
                return Ok(result);
            }
            return Ok(result);
        }



        [HttpPost,Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
                return BadRequest("Invalid Request");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var param = new Dictionary<string, string?>
            {
                {"token",token },
                {"email",forgotPasswordDto?.Email},
            };

            var callback = QueryHelpers.AddQueryString(forgotPasswordDto.ClientURI, param);
            Message ? message = new Message( "Reset password token", callback, null);
            await _sendGridClient.SendEmailAsync(msg);
            return Ok();
        }


        //[Authorize]
        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] AddRole addRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.AddRole(addRole);

            if (!string.IsNullOrEmpty(result))
            {
                return Ok(result);
            }
            return Ok(addRole);
        }


        [HttpGet,Route("GetRole")]
        public List<ApplicationRole> GetRole()
        {
            var roles = _roleManager.Roles.ToList();
            return roles;
        }
        [HttpGet,Route("GetRoleById")]
        public List<ApplicationRole> GetRoleById(string id)
        {
            var role = _roleManager.Roles.Where(r=>r.Id == id).ToList();
              
            return role;
        }

    }
}
