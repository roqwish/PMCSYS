using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class User
    {
        public User(int UID1, string email1, string phone_number1, string password1, string name1, string surname1, string organization1, string role_in_system1)
        {
            UID = UID1;
            email = email1;
            phone_number = phone_number1;
            password = password1;
            name = name1;
            surname = surname1;
            organization = organization1;
            role_in_system = role_in_system1;
        }
        public int UID { get; }
        protected string email { get; }
        protected string phone_number { get; }
        protected string password { get; }
        protected string name { get; }
        protected string surname { get; }
        protected string organization { get; }
        protected string role_in_system { get; }
    }
}
