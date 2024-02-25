using Dappercrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dappercrud.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = null;
        // GET: Product
        public ActionResult Index()
        {
            productRepository = new ProductRepository();
            return View(productRepository.GetAllProduct());
        }

        // GET: Details
        [HttpGet]
        public ActionResult Details(int prodId)
        {
            productRepository = new ProductRepository();
            return View(productRepository.GetProductByProductId(prodId));
        }

        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productRepository = new ProductRepository();
                    int x = productRepository.AddProduct(p);
                    if (x > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Edit
        [HttpGet]
        public ActionResult Edit(int prodId)
        {
            productRepository = new ProductRepository();
            return View(productRepository.GetProductByProductId(prodId));
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productRepository = new ProductRepository();
                    int x = productRepository.UpdateProduct(p);
                    if (x > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int prodId)
        {
            productRepository = new ProductRepository();
            return View(productRepository.GetProductByProductId(prodId));
        }

        // POST: Delete
        [HttpPost]
        [ActionName("Delete")] 
        [ValidateAntiForgeryToken]
        public ActionResult Delete_Post(int prodId)
        {
            try
            {
                productRepository = new ProductRepository();
                int x = productRepository.DeleteProduct(prodId);
                if (x > 0)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
