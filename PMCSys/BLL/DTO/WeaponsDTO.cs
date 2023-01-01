using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class WeaponsDTO
    {
        public int weapon_id { get; set; }
        private String name { get; set; }
        private String category { get; set; }
        private int amount { get; set; }
        private int weight { get; set; }
        private StorageDTO storage { get; set; }

        public WeaponsDTO getDetailsAboutWeapons()
        {
            WeaponsDTO weapons = new WeaponsDTO(this.weapon_id, this.name, this.category, this.amount, this.weight, this.storage.getStorage());
            return weapons;
        }

        public WeaponsDTO(int weapon_id, String name, String category, int amount, int weight, StorageDTO storage)
        {
            this.weapon_id = weapon_id;
            this.name = name;
            this.category = category;
            this.amount = amount;
            this.weight = weight;
            this.storage = storage;
        }

        public WeaponsDTO() { }
    }
}
