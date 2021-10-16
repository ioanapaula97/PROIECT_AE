using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Entites;
using ProiectMaster.Models.Interfaces;

namespace ProiectMaster.Web.Controllers
{
    [Route("[Controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService service;
        private readonly IProductService prodService;
        private readonly IOrderProductService orderProdService;

        public OrderController(IOrderService service, IProductService prodService, IOrderProductService orderProdService)
        {
            this.service = service;
            this.prodService = prodService;
            this.orderProdService = orderProdService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = service.GetAllOrders();
            return View(list);
        }

   
        [HttpGet]
        [Route("New")]
        public IActionResult New()
        {
            IEnumerable<int> cartProductsIds = HttpContext.Session.Get<List<int>>(SessionHelper.ShoppingCart);
            IEnumerable<ProductVM> list = prodService.GetAllProductsByIds(cartProductsIds);
            //return View(list);
            ViewData["productsList"] = list;
            var dto = new OrderVM();
            return View(dto);
        }

        [HttpPost]
        [Route("New")]
        public IActionResult New(OrderVM dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                return View(dto);
            }

            List<int> cartProductsIds = HttpContext.Session.Get<List<int>>(SessionHelper.ShoppingCart);
            bool orderSavedWithSuccess = service.AddOrder(dto, cartProductsIds);

            if (cartProductsIds != null && cartProductsIds.Count() > 0 && orderSavedWithSuccess)
            {
                cartProductsIds = new List<int>();
                HttpContext.Session.Set(SessionHelper.ShoppingCart, cartProductsIds);
            }

            return View("~/Views/Home/Index.cshtml", prodService.GetAllProducts());
        }

    }
}
