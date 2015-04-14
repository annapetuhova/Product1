using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace Lesson4.Controllers
{

    public class Product
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
    };

    public class ProductsController : Controller
    {
        public List<Product> Products = new List<Product>()
        {
            //Создадим несколько продуктов
            new Product() {Category = "Концелярия", Code = "FF-001", Title = "Карандаш",Date = new DateTime(2000,01,01)},
            new Product() {Category = "Концелярия", Code = "FF-002", Title = "Тетрадка", Date = new DateTime(2000,01,02)},
            new Product() {Category = "Концелярия", Code = "FF-002", Title = "Ручка",Date = new DateTime(2000,01,03)},
            new Product() {Category = "Еда", Code = "EE-002", Title = "Крупа",Date = new DateTime(2000,01,03)},
            new Product() {Category = "Еда", Code = "EE-002", Title = "Хлеб",Date = new DateTime(2000,01,01)}
        };

        public ActionResult Index(string code)
        {
            ViewBag.Products = Products; //передаем наши продукты

            return View();
        }

        public ActionResult Product(string code) 
        {
            var product = Products.First(prod => prod.Code == code);
            ViewBag.Product = product; 
            
            return View();
        }

        public ActionResult PrintProduct(string code)
        {
            var product = Products.First(prod => prod.Code == code);
            ViewBag.Product = product;
            return View();
        }


        public ActionResult ShowByCats(string cat, int page)
        {
            var products = Products.Where(prod => prod.Category == cat);
            ViewBag.Products = products;
            ViewBag.Page = page;
            return View();
        }

        public ActionResult ShowByDate(string date, int page)
        {
            var date1 = DateTime.Parse(date);
            var products = Products.Where(prod => prod.Date == date1);
            ViewBag.Products = products;
            ViewBag.Page = page;
            return View();
        }
    }
}       