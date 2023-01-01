using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Employee
        : User
    {
        public Employee(int UID1, string email1, string phone_number1, string password1, string name1, string surname1, string organization1)
            : base(UID1, email1, phone_number1, password1, name1, surname1, organization1, nameof(Employee))
        {
        }
    }
}
