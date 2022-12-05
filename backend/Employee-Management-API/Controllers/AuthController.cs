using AutoMapper;
using Employee_Management_API.DTOs;
using Employee_Management_API.Models;
using Employee_Management_API.Models.Responses;
using Employee_Management_API.Repository.AuthRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace Employee_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepo authRepo,
            IMapper mapper)
        {
            _authRepo = authRepo;
            _mapper = mapper;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> onSignIn(User _user)
        {

            if (_user != null && _user.Email != null && _user.Password != null)
            {
                AuthResponse result = await _authRepo.SignIn(_user);
                if (result.Success == true && result.AccessToken != null && result.AuthUser != null)
                {
                    var mappedUser = _mapper.Map<UserDTO>(result.AuthUser);
                    var tokenOutput = new TokenModel()
                    {
                        AccessToken = result.AccessToken,
                        AuthUser = mappedUser
                    };
                    return Ok(tokenOutput);
                }
                else if (result.Success == false)
                {
                    return Unauthorized("Invalid credentials");
                }

            }
            return BadRequest();
        }

    }
}
