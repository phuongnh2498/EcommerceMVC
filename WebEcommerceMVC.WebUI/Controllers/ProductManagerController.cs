using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEcommerceMVC.Core.Models;
using WebEcommerceMVC.DataAccess.InMemory;
namespace WebEcommerceMVC.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository productRepository;
        public ProductManagerController() {
            if(productRepository==null)
             productRepository = new ProductRepository(); 
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            Console.WriteLine(productRepository);
            List<Product> products = productRepository.GetAll();
            return View(products);
        }

        // GET: ProductManager/Details/5
        public ActionResult Details(string id)
        {
            Product product = productRepository.Find(id);
            if(product==null) return HttpNotFound();
            return View(product);
        }

        // GET: ProductManager/Create
        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        // POST: ProductManager/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (!ModelState.IsValid) {
                    return View(product);
                }
                // TODO: Add insert logic here
                productRepository.Insert(product);
                productRepository.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                //this.FlashError("There was an error Create this record");
                return View(product);
            }
        }

        // GET: ProductManager/Edit/5
        public ActionResult Edit(string Id)
        {
            Product product = productRepository.Find(Id);
            if (product == null) {
             return HttpNotFound();
            }

            return View(product);
        }

        // POST: ProductManager/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product,string Id)
        {
            try
            {
                Product productToUpdate = productRepository.Find(Id);
                if (product == null) return HttpNotFound(); 
                if (!ModelState.IsValid)  return View(product);

                productToUpdate.Category = product.Category;
                productToUpdate.Description = product.Description;
                productToUpdate.Price = product.Price; 
                productToUpdate.Image = product.Image;
                productToUpdate.Name = product.Name;

                productRepository.Commit();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductManager/Delete/5
        public ActionResult Delete(string Id)
        {
            Product product = productRepository.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ProductManager/Delete/5
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult ConfirmDelete(string Id)
        {
            try
            {
                Product product = productRepository.Find(Id);
                if (product == null) return HttpNotFound();
                // TODO: Add delete logic here
                productRepository.Delete(Id);
                productRepository.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
