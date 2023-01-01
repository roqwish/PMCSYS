using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class RequestDTO
    {
        public int request_id { get; set; }
        private CustomerDTO customer { get; set; }
        private DateTime created_on { get; set; }
        private DateTime deadline { get; set; }
        private int cost { get; set; }
        private WeaponsDTO weapons { get; set; }

        public RequestDTO getRequest()
        {
            RequestDTO request = new RequestDTO(this.request_id, this.customer.getCustomer(), this.created_on, this.deadline, this.cost, this.weapons.getDetailsAboutWeapons());
            return request;
        }
        public CustomerDTO getRequestCustomer()
        {
            CustomerDTO customer = this.customer.getCustomer();
            return customer;
        }

        public WeaponsDTO getRequestWeapons()
        {
            WeaponsDTO weapons = this.weapons.getDetailsAboutWeapons();
            return weapons;
        }

        public int getCost()
        {
            return this.cost;
        }

        public DateTime getDeadline()
        {
            return this.deadline;
        }

        public RequestDTO(int request_id, CustomerDTO customer, DateTime created_on, DateTime deadline, int cost, WeaponsDTO weapons)
        {
            this.request_id = request_id;
            this.customer = customer;
            this.created_on = created_on;
            this.deadline = deadline;
            this.cost = cost;
            this.weapons = weapons;
        }

        public RequestDTO() { }

    }
}
