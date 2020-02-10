using System;
using System.Collections.Generic;
using System.Text;

namespace lab10_ATM
{
    class Account
    {
    
        private string name;
        private string password;
        private double balance;

       
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        
        public Account()
        {

        }

        public Account(string _name, string _password)
        {
            name = _name;
            password = _password;
        }

        public Account(string _name, string _password, double _balance) //for testing
        {
            name = _name;
            password = _password;
            balance = _balance;
        }

    }
}
