using Employee_Management_API.Data;
using Employee_Management_API.Models;
using Employee_Management_API.Models.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Employee_Management_API.Repository.AuthRepository
{
    public class AuthRepo : IAuthRepo
    {

        public IConfiguration _configuration;
        private readonly employeemanagementdbContext _context;

        public AuthRepo(
            IConfiguration configuration,
            employeemanagementdbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<AuthResponse> SignIn(User _user)
        {
            if (_user != null && _user.Email != null && _user.Password != null)
            {
                var user = await getUser(_user.Email, _user.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                                new Claim("UserId", user.Id.ToString()),
                                new Claim("Email", user.Email),
                            };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    //var mappedUser = _mapper.Map<FournisseurContactLoginResponseDTO>(user);
                    var authResponse = new AuthResponse()
                    {
                        Success = true,
                        AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                        AuthUser = user
                    };
                    //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    return authResponse;
                }
                else
                {
                    var authResponse = new AuthResponse()
                    {
                        Success = false,
                    };
                    return authResponse;
                }
            }
            else
            {
                var authResponse = new AuthResponse()
                {
                    Success = false,
                };
                return authResponse;
            }
        }

        public async Task<User> getUser(string _email, string _password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == _email && u.Password == _password);
        }
    }
}
