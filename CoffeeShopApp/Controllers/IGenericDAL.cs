using CoffeeShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopApp.Controllers
{
    interface IGenericDAL
    {
        List<User> GetUserList();

        bool FindUser(string primaryKey);

        bool CheckPassword(string email, string password);

        void AddNewUser(User user);

        List<Item> GetItemList();

        bool FindItem(string primaryKey);

        void AddNewItem(Item newItem);

        void DeleteItem(string primaryKey);

        Item UpdateItem(string primaryKey);

        void SaveUpdatedItem(Item updatedItem);
    }
}
