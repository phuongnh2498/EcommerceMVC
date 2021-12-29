using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEcommerceMVC.Core;
using System.Runtime.Caching;
using WebEcommerceMVC.Core.Models;

namespace WebEcommerceMVC.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;
        public ProductRepository() {
            products = cache["products"] as List<Product>;
            if (products == null) {
                products= new List<Product>();
            }
        }
        public void Commit() {
            cache["product"] = products;
        }

        public void Insert() {
            products.Add(new Product());
        }
        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p=>p.Id==product.Id);
            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else throw new Exception("Product not found");

        }
        public Product Find(String Id) {
            Product product = products.Find(p => p.Id == Id);
            if (product != null)
            {
                return product;
            }
            else throw new Exception("Product not found");
        }
        public List<Product> GetAll() {
            return products;
        }
        public void Delete(string Id) {
            Product product = products.Find(p => p.Id == Id);
            if (product != null)
            {
                 products.Remove(product);
            }
            else throw new Exception("Product not found");
        }
    }
}
