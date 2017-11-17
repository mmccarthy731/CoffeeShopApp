using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShopApp.Models
{
    public class User
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private string password;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public User() : this("", "", "", "", "")
        {

        }

        public User(string firstName, string lastName, string email, string phoneNumber, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.password = password;
        }
    }
}