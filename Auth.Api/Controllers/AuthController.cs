using Auth.Api.Models;
using Auth.Domain.Entity;
using Auth.Domain.Utils;
using Auth.Service.Interface;
using Auth.Service.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace Auth.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        public AuthController(IUserService userService, IJwtService jwtService) 
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] SignInRequest signInModel) 
        {
            var response = new ResponseModel<SignInResponse>();
            var authResult = await _userService.Login(signInModel);

            if (!authResult.IsSuccessful)
            {
                response.IsSuccessful = false;
                response.Message = authResult.Message;

                return Unauthorized(response);
            }
            var user = authResult.Result;
            // Create token form user object
            var token = _jwtService.GenerateJwtToken(user);

            response.IsSuccessful = true;
            response.Message = ServiceMessage.Success;
            response.Result = new SignInResponse 
            { 
                UserId = user.UserId, 
                Username = user.Username, 
                Firstname = user.Firstname, 
                Lastname = user.Lastname, 
                Token = token 
            };

            return Ok(response);
        } 
    }
}
