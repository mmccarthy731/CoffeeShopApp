using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShopApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace CoffeeShopApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        public ActionResult RegisterNewUser(User NewUser)
        {
            if (ModelState.IsValid)
            {
                CoffeeShopEntities ORM = new CoffeeShopEntities();

                ORM.Users.Add(NewUser);
                ORM.SaveChanges();

                return View("Index");
            }
            else
            {
                return RedirectToAction("UserRegistration");
            }
        }

        public ActionResult ListProducts()
        {
            CoffeeShopEntities ORM = new CoffeeShopEntities();

            List<Item> productList = ORM.Items.ToList();

            ViewBag.ProductList = productList;

            return View("ListProducts");
        }

        public ActionResult DeleteProduct(string name)
        {
            CoffeeShopEntities ORM = new CoffeeShopEntities();

            Item itemToDelete = ORM.Items.Find(name);
            
            if (itemToDelete != null)
            {
                ORM.Items.Remove(itemToDelete);
                ORM.SaveChanges();
            }

            return RedirectToAction("ListProducts");
        }

        public ActionResult UpdateProduct(string name)
        {
            CoffeeShopEntities ORM = new CoffeeShopEntities();

            Item itemToUpdate = ORM.Items.Find(name);

            if (itemToUpdate != null)
            {
                ViewBag.ItemToUpdate = itemToUpdate;

                return View("UpdateItemForm");
            }
            else
            {
                return RedirectToAction("ListProduts");
            }
        }

        public ActionResult SaveUpdatedItem(Item itemToUpdate)
        {
            CoffeeShopEntities ORM = new CoffeeShopEntities();

            Item temp = ORM.Items.Find(itemToUpdate.Name);

            temp.Description = itemToUpdate.Description;
            temp.Quantity = itemToUpdate.Quantity;
            temp.Price = itemToUpdate.Price;

            ORM.Entry(temp).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();

            return RedirectToAction("ListProducts");
        }
    }
}