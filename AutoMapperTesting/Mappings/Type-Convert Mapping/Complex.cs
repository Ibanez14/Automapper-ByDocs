using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperTesting.Models
{

    public class ComplexModel
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public Type ClassType { get; set; }

    }

    public class ComplexModelDTO
    {
        public string Name { get; set; }
        public int CreationDate { get; set; }
        public string ClassType { get; set; }
    }



    /// <summary>
    /// Mapping complex type with type conversion. Here we use global type conversion
    /// </summary>
    public class ComplexTypeMapping : Profile
    {
        public ComplexTypeMapping()
        {
            // Since this models has different types in it
            // we should configure type conversion
            CreateMap<ComplexModel, ComplexModelDTO>();
            CreateMap<Type, string>()
                .ConvertUsing(new TypeToStringConverter());

            CreateMap<DateTime, int>()
                .ConvertUsing(new DateTimeToStringConverter());
        }
    }



    #region Type conversion

    // This is bad practise since will convert all globally
    public class TypeToStringConverter : ITypeConverter<Type, string>
    {
        public string Convert(Type source, string destination, ResolutionContext context)
        {
            return source.Name;
        }
    }


    // This is bad practise since will convert all globally
    public class DateTimeToStringConverter : ITypeConverter<DateTime, int>
    {
        public int Convert(DateTime source, int destination, ResolutionContext context)
        {
            return source.Year;
        }
    }

    #endregion

}
