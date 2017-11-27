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
                CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();

                if (ORM.Users.Find(NewUser.Email) != null)
                {
                    ViewBag.RegistrationError = "An account with the provided email address already exists.";
                    return View("UserRegistration");
                }

                ORM.Users.Add(NewUser);
                ORM.SaveChanges();

                return RedirectToAction("ListProducts");
            }
            else
            {
                return View("UserRegistration");
            }
        }

        public ActionResult ListProducts()
        {
            CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();

            List<Item> productList = ORM.Items.ToList();

            ViewBag.ProductList = productList;

            return View("ListProducts");
        }

        public ActionResult DeleteProduct(string name)
        {
            CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();

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
            CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();

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
            CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();

            Item temp = ORM.Items.Find(itemToUpdate.Name);

            temp.Description = itemToUpdate.Description;
            temp.Quantity = itemToUpdate.Quantity;
            temp.Price = itemToUpdate.Price;

            ORM.Entry(temp).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();

            return RedirectToAction("ListProducts");
        }

        public ActionResult AddItem()
        {

            return View("AddItemForm");
        }

        public ActionResult AddNewItem(Item item)
        {
            if (ModelState.IsValid)
            {
                CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();

                ORM.Items.Add(item);
                ORM.SaveChanges();

                return RedirectToAction("ListProducts");
            }

            return View("AddItemForm");
        }

        public ActionResult SignIn(string Email, string Password)
        {
            CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();

            User user = ORM.Users.Find(Email);

            if (user == null)
            {
                ViewBag.SignInError = "There is no account associated with that email address.";
                return View("UserRegistration");
            }
            else if (Password != user.Password)
            {
                ViewBag.SignInError = "Incorrect Password. Please try again.";
                return View("UserRegistration");
            }
            else
            {
                return RedirectToAction("ListProducts");
            }
        }
    }
}