using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProiectMaster.DataAccess.Interfaces;
using ProiectMaster.Models.DTOs;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Entites;
using ProiectMaster.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProiectMaster.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order, int> orderRep;
        private readonly IMapper mapper;
        private readonly IOrderProductService orderProdService;

        public OrderService(IRepository<Order, int> orderRep, IMapper mapper, IOrderProductService orderProdService)
        {
            this.orderRep = orderRep;
            this.mapper = mapper;
            this.orderProdService = orderProdService;
        }

        public bool AddOrder(OrderVM dto, List<int> productsIds)
        {
            Boolean orderSavedWithSuccess = false;
            if(productsIds != null && productsIds.Count() > 0)
            {
                dto.OrderDate = System.DateTime.Now;
                var entity = mapper.Map<Order>(dto);
                
                Order savedOrder =  orderRep.AddAndReturn(entity);

                productsIds.ForEach(prodId =>
                {
                    OrderProductVM op = new OrderProductVM();
                    op.OrderId = savedOrder.Id;
                    op.ProductId = prodId;
                    orderProdService.AddOrderProduct(op);
            });
                orderSavedWithSuccess = true;
            }
            return orderSavedWithSuccess;
            
        }

        public IEnumerable<OrderVM> GetAllOrders()
        {
            var list = orderRep.GetAll();
            IEnumerable<OrderVM> dtoList = mapper.Map<List<OrderVM>>(list);
            
            return dtoList;
        }

        public OrderVM GetOrder(int id)
        {
            var entity = orderRep.GetInstance(id);
            return mapper.Map<OrderVM>(entity);
        }
    }
}
