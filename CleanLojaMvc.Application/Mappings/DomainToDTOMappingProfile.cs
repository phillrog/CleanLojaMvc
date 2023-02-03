using AutoMapper;
using CleanLojaMvc.Application.DTOs;
using CleanLojaMvc.Application.Products.Commands;
using CleanLojaMvc.Domain.Entities;

namespace CleanLojaMvc.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
            CreateMap<ProductDTO, ProductRemoveCommand>();
        }
    }
}
