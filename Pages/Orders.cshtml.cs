using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SportsStore.Data;
using SportsStore.Models;

namespace SportsStore.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly IRepositoryWrapper _repository;
        private List<Order> Orders;
        public OrdersModel(IRepositoryWrapper repository)
        {
            Orders = new List<Order>();
            _repository = repository;
        }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            //Set value of return url
            ReturnUrl = returnUrl ?? "/";
        }

        public IQueryable<Order> unshippedorders
        {
            get
            {
                return _repository.Order.GetOrders();
            }
        }

        public List<Order> ShippedOrders
        {
            get
            {

                return Orders;
            }
        }

       public IActionResult OnPost(int OrderID, string returnUrl)
        {
            Order order = _repository.Order.GetById(OrderID);
            Orders.Add(order);
            _repository.Order.Delete(order);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
