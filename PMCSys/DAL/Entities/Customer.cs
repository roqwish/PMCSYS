using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }
        private String name { get; set; }
        private String surname { get; set; }
        private String phone_number { get; set; }
        private String organization { get; set; }

        public Customer getCustomer() { 
            Customer customer = new Customer(this.customer_id, this.name, this.surname, this.phone_number, this.organization);
            return customer;
        }

        public Customer(int customer_id, String name, String surname, String phone_number, String organization)
        {
            this.customer_id = customer_id;
            this.name = name;
            this.surname = surname;
            this.phone_number = phone_number;
            this.organization = organization;
        }

        public Customer() {}
    }
}
