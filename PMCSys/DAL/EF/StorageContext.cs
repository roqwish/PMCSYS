using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;

namespace DAL.EF
{
    public class StorageContext : DbContext
    {
        public DbSet<Storage> storages { get; set; }
        public DbSet<Request> requests { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Weapons> weapons { get; set; }

        public StorageContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}