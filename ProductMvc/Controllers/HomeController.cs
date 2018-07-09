using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ProductMvc.Models;

namespace ProductMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Products");
        }



        [HttpGet]
        public ActionResult GetData()
        {
            HttpResponseMessage responseLaptops = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            int laptops = responseLaptops.Content.ReadAsAsync<IEnumerable<ProductDto>>().Result.Count(c => c.Category.Name == "Laptops");

            HttpResponseMessage responseMobiles = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            int mobiles = responseMobiles.Content.ReadAsAsync<IEnumerable<ProductDto>>().Result.Count(c => c.Category.Name == "Mobiles");

            HttpResponseMessage responseDesktops = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            int desktops = responseDesktops.Content.ReadAsAsync<IEnumerable<ProductDto>>().Result.Count(c => c.Category.Name == "Desktops");


            Ratio obj = new Ratio();
            obj.Laptops = laptops;
            obj.Mobiles = mobiles;
            obj.Desktops = desktops;

            ViewBag.LAPTOPS = laptops;
            ViewBag.MOBILES = mobiles;
            ViewBag.DESKTOPS = desktops;

            return View(obj);
        }

    }
}