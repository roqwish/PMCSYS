using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Weapons
    {
        [Key]
        public int weapon_id { get; set; }
        private String name { get; set; }
        private String category { get; set; }
        private int amount { get; set; }
        private int weight { get; set; }
        private Storage storage { get; set; }

        public Weapons getDetailsAboutWeapons() { 
            Weapons weapons = new Weapons(this.weapon_id, this.name, this.category, this.amount, this.weight, this.storage.getStorage());
            return weapons;
        }

        public Weapons(int weapon_id, String name, String category, int amount, int weight, Storage storage)
        {
            this.weapon_id = weapon_id;
            this.name = name;
            this.category = category;
            this.amount = amount;
            this.weight = weight;
            this.storage = storage;
        }

        public Weapons() { }
    }
}
