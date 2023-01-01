using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class CustomerDTO
    {
        public int customer_id { get; set; }
        private String name { get; set; }
        private String surname { get; set; }
        private String phone_number { get; set; }
        private String organization { get; set; }

        public CustomerDTO getCustomer()
        {
            CustomerDTO customer = new CustomerDTO(this.customer_id, this.name, this.surname, this.phone_number, this.organization);
            return customer;
        }

        public CustomerDTO(int customer_id, String name, String surname, String phone_number, String organization)
        {
            this.customer_id = customer_id;
            this.name = name;
            this.surname = surname;
            this.phone_number = phone_number;
            this.organization = organization;
        }

        public CustomerDTO() { }
    }
}
