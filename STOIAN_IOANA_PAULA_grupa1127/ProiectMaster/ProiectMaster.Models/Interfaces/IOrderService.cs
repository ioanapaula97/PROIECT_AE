using System;
using System.Collections.Generic;
using ProiectMaster.Models.DTOs;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Entites;

namespace ProiectMaster.Models.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderVM> GetAllOrders();
        OrderVM GetOrder(int id);
        bool  AddOrder(OrderVM dto, List<int> productsIds);
    }
}
