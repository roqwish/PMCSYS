using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using Moq;

namespace DAL.Tests
{
    class TestRequestRepository
        : BaseRepository<Request>
    {
        public TestRequestRepository(DbContext context) 
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputRequestInstance_CalledAddMethodOfDBSetWithRequestInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<StorageContext>()
                .Options;
            var mockContext = new Mock<StorageContext>(opt);
            var mockDbSet = new Mock<DbSet<Request>>();
            mockContext
                .Setup(context => 
                    context.Set<Request>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestRequestRepository(mockContext.Object);

            Request expectedRequest = new Mock<Request>().Object;

            //Act
            repository.Create(expectedRequest);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedRequest
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<StorageContext>()
                .Options;
            var mockContext = new Mock<StorageContext>(opt);
            var mockDbSet = new Mock<DbSet<Request>>();
            mockContext
                .Setup(context =>
                    context.Set<Request>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IItemRepository repository = uow.Items;
            var repository = new TestRequestRepository(mockContext.Object);

            Request expectedRequest = new Request(1, new Customer(1, "", "", "", ""),
                new DateTime(), new DateTime(), 0, new Weapons(1, "", "", 0, 0, new Storage(1, "", "", 0)));
            mockDbSet.Setup(mock => mock.Find(expectedRequest.getRequest().request_id)).Returns(expectedRequest);

            //Act
            repository.Delete(expectedRequest.request_id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedRequest.request_id
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedRequest
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<StorageContext>()
                .Options;
            var mockContext = new Mock<StorageContext>(opt);
            var mockDbSet = new Mock<DbSet<Request>>();
            mockContext
                .Setup(context =>
                    context.Set<Request>(
                        ))
                .Returns(mockDbSet.Object);

            Request expectedRequest = new Request(1, new Customer(1, "", "", "", ""),
                 new DateTime(), new DateTime(), 0, new Weapons(1, "", "", 0, 0, new Storage(1, "", "", 0)));
            mockDbSet.Setup(mock => mock.Find(expectedRequest.request_id))
                    .Returns(expectedRequest);
            var repository = new TestRequestRepository(mockContext.Object);

            //Act
            var actualRequest = repository.Get(expectedRequest.request_id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedRequest.request_id
                    ), Times.Once());
            Assert.Equal(expectedRequest, actualRequest);
        }

      
    }
}
