using CoffeeShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShopApp.Controllers
{
    public class CoffeeShopDAL : IGenericDAL
    {
        CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();

        public List<User> GetUserList()
        {
            List<User> userList = ORM.Users.ToList();
            return userList;
        }

        public bool FindUser(string primaryKey)
        {
            if (ORM.Users.Find(primaryKey) == null)
            {
                return false;
            }
            return true;
        }

        public bool CheckPassword(string email, string password)
        {
            User user = ORM.Users.Find(email);

            return user.Password == password;
        }

        public void AddNewUser(User user)
        {
            ORM.Users.Add(user);
            ORM.SaveChanges();
        }

        public List<Item> GetItemList()
        {
            List<Item> itemList = ORM.Items.ToList();
            return itemList;
        }

        public bool FindItem(string primaryKey)
        {
            if (ORM.Items.Find(primaryKey) == null)
            {
                return false;
            }
            return true;
        }

        public void AddNewItem(Item newItem)
        {
            ORM.Items.Add(newItem);
            ORM.SaveChanges();
        }

        public void DeleteItem(string primaryKey)
        {
            ORM.Items.Remove(ORM.Items.Find(primaryKey));
            ORM.SaveChanges();
        }

        public Item UpdateItem(string primaryKey)
        {
            return ORM.Items.Find(primaryKey);
        }

        public void SaveUpdatedItem(Item updatedItem)
        {
            Item temp = ORM.Items.Find(updatedItem.Name);

            temp.Description = updatedItem.Description;
            temp.Quantity = updatedItem.Quantity;
            temp.Price = updatedItem.Price;

            ORM.Entry(temp).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();
        }
    }
}