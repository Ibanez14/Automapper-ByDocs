using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Here we use simple mapping with Profile => ForMember
/// </summary>
namespace AutoMapperTesting.Models.Domain
{
    // DM
    public class Person
    {
        public Person(string firstName, string lastName, string email, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }

        public int Id { get; set; }
        public string FirstName { get; set;         }
        public string LastName { get; set;         }
        public string Email { get; set; }

    }

    // VM
    public class PersonViewModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
    }

    // Mapping
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            // User this in case DomainModel and VM props are different names
            CreateMap<Person, PersonViewModel>()
                    .ForMember(vm => vm.FName,
                               opt => opt.MapFrom(dm => dm.FirstName))
                    .ForMember(vm => vm.LName,
                               opt => opt.MapFrom(dm => dm.LastName))
                    .ForMember(vm => vm.Email,
                               opt => opt.MapFrom(dm => dm.Email));

        }
    }
}
