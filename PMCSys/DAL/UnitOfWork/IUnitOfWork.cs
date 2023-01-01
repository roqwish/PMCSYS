using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IStorageRepository Storages { get; }
        IRequestRepository Requests { get; }
        ICustomerRepository Customers { get; }
        IWeaponsRepository Weapons { get; }
        void Save();
    }
}

