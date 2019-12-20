using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperTesting.Models
{
    public class Bottle
    {
        public bool IsLitre;
    }

    public class BottleDTO
    {
        public string Litre;
    }



    /// <summary>
    /// Simple type conversion
    /// </summary>
    public class BottleMapping : Profile
    {
        public BottleMapping()
        {
            // Note that automapper will automatically add ToString() when destination member is string
            // and source is different
            // but you can override by ConvertUsin() as below

            CreateMap<Bottle, BottleDTO>()
              .ConvertUsing(main => new BottleDTO() { Litre = main.IsLitre ? "Yes" : "No" });

            // This is bad practise since will convert all globally
            CreateMap<int, string>().ConvertUsing(i => i.ToString() + " addition");
            // or you can use more advanced converter

        }
    }
}
