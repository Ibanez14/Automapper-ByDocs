using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperTesting.Models
{
    // DOMAIN
    public class Book
    {
        public string BookName { get; set; }
        public Catalog Catalog { get; set; }
    }

    public class Catalog
    {
        public string Type { get; set; }
    }



    // DTO-s
    public class BookDTO
    {
        // Thie ctor for testing mapping in method contructUsing()
        public BookDTO(string someValue)
        {

        }

        public BookDTO()
        {

        }
        public string BookNameDTO { get; set; }
        public CatalogDTO CatalogDTO { get; set; }
    }
    public class CatalogDTO
    {
        public string TypeDTO { get; set; }
    }




    /// <summary>
    /// Complex types mapping
    /// </summary>
    public class BookCatalogProfile : Profile
    {
        public BookCatalogProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dto => dto.BookNameDTO, ops => ops.MapFrom(b => b.BookName))
                .ForMember(dto => dto.CatalogDTO, ops => ops.MapFrom(b => b.Catalog))
                .ConstructUsing((domain, dto)=> new BookDTO(domain.BookName))
                .ReverseMap();

            CreateMap<Catalog, CatalogDTO>()
                .ForMember(dto => dto.TypeDTO, ops => ops.MapFrom(c => c.Type))
                .ReverseMap();
        }
    }




}
