using System;
using System.Collections.Generic;
using ProiectMaster.Models.DTOs;
using ProiectMaster.Models.DTOs.VM;

namespace ProiectMaster.Models.Interfaces
{
    public interface IOrderProductService
    {
        void AddOrderProduct(OrderProductVM dto);
    }
}
