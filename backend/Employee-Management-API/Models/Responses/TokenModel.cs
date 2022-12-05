using Employee_Management_API.DTOs;

namespace Employee_Management_API.Models.Responses
{
    public class TokenModel
    {
        public string? AccessToken { get; set; }
        public UserDTO? AuthUser { get; set; }
    }
}
