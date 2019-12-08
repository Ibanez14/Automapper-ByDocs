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
    // DM
    public class User
    {
        public User(string firstName, string lastName, string email, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }


    // VM
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
    }

    // Map
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            //// This will map User to UserViewModel;
            //CreateMap<User, UserViewModel>();

            // Map User to UserViewModel and reverse
            CreateMap<User, UserViewModel>()
                .ReverseMap();
        }
    }
}
