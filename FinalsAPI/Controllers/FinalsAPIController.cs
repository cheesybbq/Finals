using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalsAPI.Models;

namespace FinalsAPI.Controllers
{
    public class FinalsAPIController : ApiController
    {

        public HttpResponseMessage Get()
        {
            IPTEntities dbcontext = new IPTEntities();
            var product = dbcontext.Products.ToList();
            var response = Request.CreateResponse<List<Products>>(HttpStatusCode.Accepted, product);
            return response;
        }

        public string Post(Products model)
        {
            IPTEntities dbcontext = new IPTEntities();
            Products products = new Products();
            products.ProductsID = model.ProductID();
            products.SupplierID = model.SupplierID();
            products.CategoryID = model.CategoryID();
            products.QuantityPerUnit = model.QuantityPerUnit();
            products.UnitPrice = model.UnitPrice();
            products.UnitsInStock = model.UnitsInStock();
            products.UnitsOnOrder = model.UnitsOnOrder();
            products.ReorderLevel = model.ReorderLevel();
            products.Discontinued = model.Discontinued();
            dbcontext.Products.Add(products);
            int x = dbcontext.SaveChanges();
            if (x > 0)
            {
                return "Data has been added successfully";
            }
            else
            {
                return "Failed to add the item";
            }
        }
        public string Put(int id, Products model)
        {
            IPTEntities dbcontext = new IPTEntities();
            var products = dbcontext.Products.Where(m => m.ProductsID == id).FirstOrDefault();
            products.Products = model.ProductsID;
            products.SupplierID = model.SupplierID();
            products.CategoryID = model.CategoryID();
            products.QuantityPerUnit = model.QuantityPerUnit();
            products.UnitPrice = model.UnitPrice();
            products.UnitsInStock = model.UnitsInStock();
            products.UnitsOnOrder = model.UnitsOnOrder();
            products.ReorderLevel = model.ReorderLevel();
            products.Discontinued = model.Discontinued();
            int x = dbcontext.SaveChanges();
            if (x > 0)
            {
                return "Data has been added sucessfully";
            }
            else
            {
                return "Failed to update the item";
            }

        }

        public string Delete(int id)
        {
            IPTEntities dbcontext = new IPTEntities();
            var products = dbcontext.Products.Where(m => m.ProductsID == id).FirstOrDefault();
            dbcontext.Products.Remove(products);
            int x = dbcontext.SaveChanges();
            if (x > 0)
            {
                return "Data has been deleted successfully";
            }
            else
            {
                return "Failed to delete the item";
            }
        }



    }
}
