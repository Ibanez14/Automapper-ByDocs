using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperTesting.Models
{
    public class Order
    {
        public string Id;
        public string Name;   // For testing ValueTransformers
        public string Client; // For testing Null Substitution
    }



    public class OrderDTO
    {
        public int dtoID { get; set; }
        public string Name;
        public string Client;
    }




    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dto => dto.dtoID,
                           ops => ops.ConvertUsing(new IdValueConverter(), domain => domain.Id))

                .ForMember(dto => dto.Client,
                           ops => ops.MapFrom(o => o.Client))

                .ForMember(dto => dto.Client,
                           ops => ops.NullSubstitute("Value Added by Mapper")) // Substitue the null

                // Before and After mapping handler.
                // Should be inherited from IMappingAction
                // OR can be an expression

                .BeforeMap<IdAction>()
                //.BeforeMap((main, dto) => main.Id = "asdasdas")
                .AfterMap((main, dto) => dto.dtoID += 100);
                //.AfterMap<>()

            // This will transform all string in one specified
            this.ValueTransformers.Add<string>(s => s + " jude");
        }
    }


    /// <summary>
    /// Action that goes can be done before or after mapping depending on configuration in profile
    /// This one is registered in before mapping action
    /// </summary>
    public class IdAction : IMappingAction<Order, OrderDTO>
    {
        // Can inject anything
        public IdAction()
        {
            
        }

        public void Process(Order source, OrderDTO destination, ResolutionContext context)
        {
            destination.dtoID = -1;
        }
    }



    public class IdValueConverter : IValueConverter<string, int>
    {
        public int Convert(string sourceMember, ResolutionContext context)
        {
            int.TryParse(sourceMember, out int result);
            return result + 100;
        }
    }

}
