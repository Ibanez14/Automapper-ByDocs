using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperTesting.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperTesting.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MainController : ControllerBase
    {
        /// <summary>
        /// Registered in Startup
        /// </summary>
        private readonly IMapper mapper;
        public MainController(IMapper mapper)
        {
            this.mapper = mapper;
        }


        [HttpGet]
        /// <summary>
        /// Mapping configuration is in Person.cs. Here Mapping is configured in PersonProfile class
        /// Not convetion based
        /// </summary>
        /// <returns></returns>
        public IActionResult ConfigureMapping()
        {
            var person = new Person("Steve", "Corney", "steve@oxbridge.com", "Ottawa");
            var personVM = mapper.Map<PersonViewModel>(person);
            return Ok(personVM);
        }







        /// <summary>
        /// Mapping configuration in User.cs
        /// Here mapping based on convention where properties of Domain and ViewModel should be matching
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ConventionMapping()
        {
            var user = new User("Steve", "Corney", "steve@oxbridge.com", "Ottawa");
            var userVM = mapper.Map<UserViewModel>(user);
            var userReversed = mapper.Map<User>(userVM);
            return Ok(userVM);
        }






    }
}
