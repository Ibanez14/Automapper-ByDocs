using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

/// <summary>
/// Here we use default mapping with Profile, with REVERSE MAPPING
/// </summary>
namespace AutoMapperTesting.Models.Domain
{
    // DOMAIN
    public class User
    {
        public User(string firstName, string email)
        {
            FirstName = firstName;
            Email = email;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }


    // DTO
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
    }





    /// <summary>
    /// Simple convention-based mapping
    /// </summary>
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //// This will map User to UserViewModel;
            //CreateMap<User, UserViewModel>();

            // Map User to UserViewModel and reverse
            CreateMap<User, UserDTO>()
                .ReverseMap();
        }
    }
}
