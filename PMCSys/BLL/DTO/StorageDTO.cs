using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTO
{
    public class StorageDTO
    {
        public int storage_id { get; set; }
        private String city { get; set; }
        private String street { get; set; }
        private int number_of_house { get; set; }

        public StorageDTO getStorage()
        {
            StorageDTO storage = new StorageDTO(this.storage_id, this.city, this.street, this.number_of_house);
            return storage;
        }

        public StorageDTO(int storage_id, string city, string street, int number_of_house)
        {
            this.storage_id = storage_id;
            this.city = city;
            this.street = street;
            this.number_of_house = number_of_house;
        }

        public StorageDTO() { }
    }
}


