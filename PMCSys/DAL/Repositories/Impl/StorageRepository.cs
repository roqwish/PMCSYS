using DAL.Entities;
using DAL.EF;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Impl
{
    public class StorageRepository : BaseRepository<Storage>, IStorageRepository
    {
      internal StorageRepository(StorageContext context) : base(context)
        {
        }
    }
}
