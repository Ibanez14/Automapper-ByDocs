using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperTesting.Models;
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
            var personVM = mapper.Map<PersonDTO>(person);
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
            var user = new User("Steve", "steve@oxbridge.com");
            var userVM = mapper.Map<UserDTO>(user);
            var userReversed = mapper.Map<User>(userVM);
            return Ok(userVM);
        }

        /// <summary>
        /// Mapping of collections
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListAndArrayMapping()
        {
            var users = new[]
            {
                new User("S", "as"),
                new User("S", "as"),
                new User("S", "as"),
                new User("S", "as")
            };
            var usersVM = mapper.Map<UserDTO[]>(users);
            var usersVMs = mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok();
        }


        /// <summary>
        /// Here we test complex type mapping with nested mappings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult TestingNesteMapping()
        {

            var book = new Book()
            {
                BookName = "Ham",
                Catalog = new Catalog()
                {
                    Type = "Horror"
                }
            };
            var bookDTO = mapper.Map<BookDTO>(book);

            return Ok();
        }


        /// <summary>
        /// Testing complex Mapping with type conversion wher converters are global levels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult TestSimpleConversion()
        {
            // Simle type conversion bool to string
            var bottle1 = new Bottle() { IsLitre = true };
            var bottleDTO1 = mapper.Map<BottleDTO>(bottle1);

            // Complext conversion see Bottle.cs
            var complex = new ComplexModel()
            {
                ClassType = typeof(ProblemDetails),
                CreationDate = DateTime.UtcNow,
                Name = "Johny B.Good"
            };

            var complextDTO = mapper.Map<ComplexModelDTO>(complex);

            return Ok();
        }


        /// <summary>
        /// Test complext mapping with type conversion where converters are local level
        /// +
        /// Value Transformer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult TestComplexConversion()
        {
            var order = new Order() { Id = "1414" };
            var orderDTO = mapper.Map<OrderDTO>(order);

            return Ok();
        }


        public IActionResult TestQueryableExtension()
        {

            // 1
            // There is no OrderLine model in this app

            // Just for demonstration purposes
            // Will get from DB only data that you need 

            //using (var context = new orderEntities())
            //{
            //    return context.OrderLines.Where(ol => ol.OrderId == orderId)
            //             .ProjectTo<OrderLineDTO>().ToList();
            //}


            // 2
            // LINQ can support aggregation queries

            //CreateMap<Course, CourseModel>()
            //.ForMember(m => m.EnrollmentsStartingWithA,
            //  opt => opt.MapFrom(c => c.Enrollments.Where(e => e.Student.LastName.StartsWith("A")).Count()));

            return NotFound();
        }

    }
}
