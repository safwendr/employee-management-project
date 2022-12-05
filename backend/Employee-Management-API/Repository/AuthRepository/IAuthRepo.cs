using Employee_Management_API.Models;
using Employee_Management_API.Models.Responses;

namespace Employee_Management_API.Repository.AuthRepository
{
    public interface IAuthRepo
    {
        public Task<AuthResponse> SignIn(User _user);
        public Task<User> getUser(string _email, string _password);
    }   
}
