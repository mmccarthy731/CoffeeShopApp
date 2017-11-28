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
        IGenericDAL DAL;

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
            DAL = new CoffeeShopDAL();

            if (ModelState.IsValid)
            {
                if (DAL.FindUser(NewUser.Email))
                {
                    ViewBag.RegistrationError = "An account with the provided email address already exists.";
                    return View("UserRegistration");
                }

                DAL.AddNewUser(NewUser);

                return RedirectToAction("ListProducts");
            }
            else
            {
                return View("UserRegistration");
            }
        }

        public ActionResult SignIn(string Email, string Password)
        {
            DAL = new CoffeeShopDAL();

            if (!DAL.FindUser(Email))
            {
                ViewBag.SignInError = "There is no account associated with that email address.";
                return View("UserRegistration");
            }
            else if (!DAL.CheckPassword(Email, Password))
            {
                ViewBag.SignInError = "Incorrect Password. Please try again.";
                return View("UserRegistration");
            }
            else
            {
                return RedirectToAction("ListProducts");
            }
        }

        public ActionResult ListProducts()
        {
            DAL = new CoffeeShopDAL();

            ViewBag.ProductList = DAL.GetItemList();

            return View("ListProducts");
        }

        public ActionResult DeleteProduct(string name)
        {
            DAL = new CoffeeShopDAL();

            if (DAL.FindItem(name))
            {
                DAL.DeleteItem(name);
            }

            return RedirectToAction("ListProducts");
        }

        public ActionResult UpdateProduct(string name)
        {
            DAL = new CoffeeShopDAL();

            if (DAL.FindItem(name))
            {
                ViewBag.ItemToUpdate = DAL.UpdateItem(name);

                return View("UpdateItemForm");
            }
            else
            {
                return RedirectToAction("ListProduts");
            }
        }

        public ActionResult SaveUpdatedItem(Item updatedItem)
        {
            DAL = new CoffeeShopDAL();

            DAL.SaveUpdatedItem(updatedItem);

            return RedirectToAction("ListProducts");
        }

        public ActionResult AddItem()
        {
            return View("AddItemForm");
        }

        public ActionResult AddNewItem(Item item)
        {
            DAL = new CoffeeShopDAL();

            if (ModelState.IsValid)
            {
                DAL.AddNewItem(item);

                return RedirectToAction("ListProducts");
            }
            else
            {
                return View("AddItemForm");
            }
        }
    }
}