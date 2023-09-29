using AutoMapper;
using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.Utilities.AutoMapperResolvers;
using SEDC.Lamazon.ViewModels.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Utilities.AutMapperProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<CreateProductViewModel, Product>().ReverseMap();
            CreateMap<UpdateProductViewModel, Product>().ReverseMap();
            CreateMap<ProductViewModel, Product>().ReverseMap();
                //.ForMember(dest => dest.Id, opt => opt.MapFrom<NewProductIdResolver>())
                //.ForMember(dest => dest.ProductCategory, opt => opt.MapFrom<ProductProductCategoryResolver>());
        }
    }
}
