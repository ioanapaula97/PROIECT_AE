using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using ProiectMaster.DataAccess.Interfaces;
using ProiectMaster.Models.DTOs;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Entites;
using ProiectMaster.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProiectMaster.DataAccess;

namespace ProiectMaster.Services
{
    public class OrderProductService : IOrderProductService
    {
        //private readonly IRepository<OrdersProduct, int> orderProdRep;
        protected readonly MagazinVirtualContext _db;
        private readonly IMapper mapper;

        public OrderProductService(MagazinVirtualContext db, IMapper mapper)
        {
            _db = db;
            this.mapper = mapper;
        }

        public void AddOrderProduct(OrderProductVM dto)
        {
            var entity = mapper.Map<OrdersProduct>(dto);

            _db.Set<OrdersProduct>().Add(entity);
            _db.SaveChanges();
        }
    }
}
