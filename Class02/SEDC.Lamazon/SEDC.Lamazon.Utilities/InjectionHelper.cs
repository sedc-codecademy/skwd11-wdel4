using Microsoft.Extensions.DependencyInjection;
using SEDC.Lamazon.DataAccess.Implementations;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Services.Implementations;
using SEDC.Lamazon.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Utilities
{
    public static class InjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
        }

    }
}
