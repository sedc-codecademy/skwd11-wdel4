﻿using SEDC.Lamazon.ViewModels.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IOrderItemService
    {

        void CreateOrderItem(int productId, int userId);

        bool IsInActiveOrder(int productId, int orderId);

        void DeleteOrderItemById(int orderItemId);

        void UpdateOrderItem(int itemId, int change);
    }
}
