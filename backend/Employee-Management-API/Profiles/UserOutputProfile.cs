using AutoMapper;
using Employee_Management_API.DTOs;
using Employee_Management_API.Models;

namespace Employee_Management_API.Profiles
{
    public class UserOutputProfile : Profile
    {
        public UserOutputProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
