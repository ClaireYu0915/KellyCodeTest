using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestModel;

namespace KellyTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IService _iService;
        public ProductController(IService iService)
        {
            _iService = iService;
        }
        public ActionResult Index()
        {

            //
            List<Product> list = new List<Product>();
            string id = "1";
            Product product = _iService.CheckValidProduct(id);
            list.Add(product);
            

            return View(list);            
        }
        public ActionResult Buy(FormCollection fm)
        {
            int quantity = Convert.ToInt32(fm["quantity"]);
            if (quantity == 0)
            {
                return View();
            }
            else{
                if (_iService.CheckInventory("1", quantity))
                {
                    return RedirectToAction("Success");
                }
                else
                {
                    return RedirectToAction("NoEnoughProduct");
                }
            }
            
        }
        public ActionResult Success(FormCollection fm)
        {
            string cardNumber = fm["cardNumber"];
            Card card = _iService.CheckValidCard(cardNumber);
            if (card != null)
            {
                return RedirectToAction("PaySuccessful");
            }else
            {
                return View();
            }
        }
        public ActionResult NoEnoughProduct()
        {
            return View();
        }
        public ActionResult PaySuccessful()
        {
            return View();
        }
        public ActionResult PayFalse()
        {
            return View();
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}