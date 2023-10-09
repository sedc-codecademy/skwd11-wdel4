using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Shared.Exceptions.ProductCategory
{
    public class ProductCategoryException : Exception
    {
        public ProductCategoryException(string message) : base(message)
        {

        }
    }
}
