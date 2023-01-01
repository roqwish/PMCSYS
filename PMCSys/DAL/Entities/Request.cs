using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Request
    {
        [Key]
        public int request_id { get; set; }
        private Customer customer { get; set; }
        private DateTime created_on { get; set; }
        private DateTime deadline { get; set; }
        private int cost { get; set; }
        private Weapons weapons { get; set; }

        public Request getRequest() {
            Request request = new Request(this.request_id, this.customer.getCustomer(), this.created_on, this.deadline, this.cost, this.weapons.getDetailsAboutWeapons());
            return request;
        }
        public Customer getRequestCustomer()
        {
            Customer customer = this.customer.getCustomer();
            return customer;
        }

        public Weapons getRequestWeapons() { 
            Weapons weapons = this.weapons.getDetailsAboutWeapons();
            return weapons;
        }

        public int getCost() {
            return this.cost;
        }

        public DateTime getDeadline() {
            return this.deadline;
        }

        public Request(int request_id, Customer customer, DateTime created_on, DateTime deadline, int cost, Weapons weapons)
        {
            this.request_id = request_id;
            this.customer = customer;
            this.created_on = created_on;
            this.deadline = deadline;
            this.cost = cost;
            this.weapons = weapons;
        }

        public Request() { }

    }
}
