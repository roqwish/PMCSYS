using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using System.Collections.Generic;
using Remotion.Linq;

namespace DAL.Tests
{
    public class RequestRepositoryInMemoryDBTests
    {
        public StorageContext Context => SqlLiteInMemoryContext();

        private StorageContext SqlLiteInMemoryContext()
        {

            var options = new DbContextOptionsBuilder<StorageContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var context = new StorageContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public void Create_InputRequestWithId0_SetRequestId1()
        {
            // Arrange
            int expectedListCount = 1;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IRequestRepository repository = uow.Requests;

            Request request = new Request(1, new Customer(1, "", "", "", ""), 
                new DateTime(), new DateTime(), 0, new Weapons(1, "", "", 0, 0, new Storage(1, "", "", 0)));

            //Act
            repository.Create(request);
            uow.Save();
            var factListCount = context.requests.Count();

            // Assert
            Assert.Equal(expectedListCount, factListCount);
        }

        [Fact]
        public void Delete_InputExistRequestId_Removed()
        {
            // Arrange
            int expectedListCount = 0;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IRequestRepository repository = uow.Requests;
            Request request = new Request(1, new Customer(1, "", "", "", ""),
                 new DateTime(), new DateTime(), 0, new Weapons(1, "", "", 0, 0, new Storage(1, "", "", 0)));
            context.requests.Add(request);
            context.SaveChanges();

            //Act
            repository.Delete(request.request_id);
            uow.Save();
            var factStreetCount = context.weapons.Count();

            // Assert
            Assert.Equal(expectedListCount, factStreetCount);
        }

        [Fact]
        public void Get_InputExistRequestId_ReturnRequest()
        {
            // Arrange
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IRequestRepository repository = uow.Requests;
            Request expectedRequest = new Request(1, new Customer(1, "", "", "", ""),
                 new DateTime(), new DateTime(), 0, new Weapons(1, "", "", 0, 0, new Storage(1, "", "", 0)));
            context.requests.Add(expectedRequest);
            context.SaveChanges();

            //Act
            var factRequest = repository.Get(expectedRequest.request_id);

            // Assert
            Assert.Equal(expectedRequest, factRequest);
        }
    }
}
