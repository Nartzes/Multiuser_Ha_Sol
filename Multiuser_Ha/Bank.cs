using Microsoft.VisualBasic;
using Multiuser_Ha;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

// We create our instance data, and use a method to initialize our uses. Then we have a login that checks to see if the username or password matches up to any of our arrays.
// If it does it returns a different int value to the program.cs that is linked to an array element. By doing so we got our user, and the user balance we are working with.


namespace Multiuser_Ha
{
    public class Bank
    {
        private const decimal InitialBankBalance = 10000m;
        private decimal bankbal;
        private List<Users> _users;

        public Bank()
        {
            bankbal = InitialBankBalance;
            Bankclient();
        }

        public decimal BankBalance => bankbal;


        public int Login(string username, string password)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (_users[i].Username == username && _users[i].Password == password)
                {
                    return i;
                }
            }
            return -1;
        }

        public string GetUsersName(int UsersId)
        {
            return _users[UsersId].Username;
        }

        public decimal GetUsersBalance(int UsersId)
        {
            return _users[UsersId].Balance;
        }

        public void Deposit(int UsersId, decimal amount)
        {
            _users[UsersId].Deposit(amount);
            bankbal += amount;
        }

        public decimal Withdraw(int UsersId, decimal amount)
        {
            decimal withdrawnAmount = _users[UsersId].Withdraw(amount);
            bankbal -= withdrawnAmount;
            return withdrawnAmount;
        }
        private void Bankclient()
        {
            _users = new List<Users>
            {
                new Users("jlennon", "johnny", 1250m),
                new Users("pmccartney", "pauly", 2500m),
                new Users("gharrison", "georgy", 3000m),
                new Users("rstarr", "ringoy", 1000m)
            };
        }

    }
}
