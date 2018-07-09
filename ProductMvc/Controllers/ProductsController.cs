using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ProductMvc.Models;

namespace ProductMvc.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            IEnumerable<ProductDto> productList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            productList = response.Content.ReadAsAsync<IEnumerable<ProductDto>>().Result;

            return View(productList);
        }



        public ActionResult Details(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/" + id).Result;

            return View(response.Content.ReadAsAsync<ProductDto>().Result);
        }



        public ActionResult Create()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Categories").Result;
            ViewBag.categories = response.Content.ReadAsAsync<IEnumerable<CategoryDto>>().Result;

            return View();
        }



        [HttpPost]
        public ActionResult Create(ProductDto product)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Products", product).Result;
            TempData["Success"] = "Added Successfully";

            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpResponseMessage responseCat = GlobalVariables.WebApiClient.GetAsync("Categories").Result;
            ViewBag.categories = responseCat.Content.ReadAsAsync<IEnumerable<CategoryDto>>().Result;

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/" + id).Result;
            return View(response.Content.ReadAsAsync<ProductDto>().Result);

        }


        [HttpPost]
        public ActionResult Edit(ProductDto product)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Products/" + product.ProductId, product).Result;
            TempData["Success"] = "Updated Successfully";

            return RedirectToAction("Index");
        }



        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Products/" + id).Result;
            TempData["Success"] = "Deleted Successfully";

            return RedirectToAction("Index");
        }


    }
}