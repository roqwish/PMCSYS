using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private StorageContext db;
        private StorageRepository storageRepository;
        private RequestRepository requestRepository;
        private CustomerRepository customerRepository;
        private WeaponsRepository weaponsRepository;

        public EFUnitOfWork(StorageContext context)
        {
            db = context;
        }
        public IStorageRepository Storages
        {
            get
            {
                if (storageRepository == null)
                    storageRepository = new StorageRepository(db);
                return storageRepository;
            }
        }
        public IRequestRepository Requests
        {
            get
            {
                if (requestRepository == null)
                    requestRepository = new RequestRepository(db);
                return requestRepository;
            }
        }
        public ICustomerRepository Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(db);
                return customerRepository;
            }
        }
        public IWeaponsRepository Weapons
        {
            get
            {
                if (weaponsRepository == null)
                    weaponsRepository = new WeaponsRepository(db);
                return weaponsRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
