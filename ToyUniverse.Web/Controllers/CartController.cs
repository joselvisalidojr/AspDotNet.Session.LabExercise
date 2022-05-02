using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToyUniverse.Data.Models;
using ToyUniverse.Data.Repositories;
using ToyUniverse.Web.Services;
using ToyUniverse.Web.Extensions;

namespace ToyUniverseWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly IToyRepository toyRepository;
        private readonly IToyService toyService;

        public CartController(IToyService toyService, IToyRepository toyRepository)
        {
            this.toyService = toyService;
            this.toyRepository = toyRepository;
        }
        public ActionResult Index()
        {
            if (HttpContext.Session.Get("cart") == null)
            {
                List<ShoppingCart> cart = new List<ShoppingCart>();

                HttpContext.Session.SetObject("cart", cart);
            }
            return View();
        }
        private int isExist(string id)
        {
            List<ShoppingCart> cart = HttpContext.Session.GetObject<List<ShoppingCart>>("cart");
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].CToy.CToyId.Equals(id))
                    return i;
            return -1;
        }

        public ActionResult Add(string id)
        {
            if (HttpContext.Session.GetObject<List<ShoppingCart>>("cart") == null)
            {
                List<ShoppingCart> cart = new List<ShoppingCart>();
                cart.Add(new ShoppingCart { CToy = toyRepository.FindByPrimaryKey(id), SiQty = 1 });
                HttpContext.Session.SetObject("cart", cart);
            }
            else
            {
                List<ShoppingCart> cart = HttpContext.Session.GetObject<List<ShoppingCart>>("cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].SiQty++;
                }
                else
                {
                    cart.Add(new ShoppingCart { CToy = toyRepository.FindByPrimaryKey(id), SiQty = 1 });
                }
                HttpContext.Session.SetObject("cart", cart);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Remove(string id)
        {
            List<ShoppingCart> cart = HttpContext.Session.GetObject<List<ShoppingCart>>("cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction("Index");
        }

    }
}