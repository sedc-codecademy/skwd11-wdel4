using AutoMapper;
using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.ViewModels.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Utilities.AutoMapperResolvers
{
    public class OrderTotalPriceResolver : IValueResolver<Order, OrderViewModel, decimal>
    {
        public decimal Resolve(Order source, OrderViewModel destination, decimal destMember, ResolutionContext context)
        {
            decimal totalSum = 0;
            foreach(var item in source.Items)
            {
                totalSum += item.Price * item.Count;
            }
            return totalSum;
        }
    }
}
