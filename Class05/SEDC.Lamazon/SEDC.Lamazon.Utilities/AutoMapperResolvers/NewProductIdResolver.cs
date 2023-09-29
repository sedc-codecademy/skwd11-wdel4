using AutoMapper;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.ViewModels.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Utilities.AutoMapperResolvers
{
    public class NewProductIdResolver : IValueResolver<CreateProductViewModel, Product, int>
    {
        public int Resolve(CreateProductViewModel source, Product destination, int destMember, ResolutionContext context)
        {
            return StaticDb.ProductId++;
        }
    }
}
