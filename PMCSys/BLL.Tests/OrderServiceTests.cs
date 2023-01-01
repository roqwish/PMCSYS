using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using CCL.Security;
using CCL.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using User = CCL.Security.Identity.User;

namespace BLL.Tests
{
    public class OrderServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new RequestService(nullUnitOfWork));
        }

        [Fact]
        public void GetRequests_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "lorem", "ipsum", "dolor", "sit", "amet", "PMC1");
            SecurityContext.SetUser(user, true);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IRequestService requestService = new RequestService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => requestService.GetRequests(0));
        }

        [Fact]
        public void GetRequest_RequestFromDAL_CorrectMappingToRequestDTO()
        {
            // Arrange
            User user = new Ministry(1, "lorem", "ipsum", "dolor", "sit", "amet", "PMC1");
            SecurityContext.SetUser(user, true);
            var requestService = GetRequestService();

            // Act
            var actualRequestDTO = requestService.GetRequests(0).First();
            DateTime dt = new DateTime(2008, 5, 1, 8, 30, 52);
            // Assert
            Assert.True(
                actualRequestDTO.request_id == 1
                && actualRequestDTO.getCost() == 0
                );
        }

        IRequestService GetRequestService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedRequest = new Request(1, new Customer(1, "", "", "", ""),
                new DateTime(), new DateTime(2008, 5, 1, 8, 30, 52), 0, new Weapons(1, "", "", 0, 0, new Storage(1, "", "", 0)));
            var mockDbSet = new Mock<IRequestRepository>();
            mockDbSet.Setup(z => 
                z.Find(
                    It.IsAny<Func<Request,bool>>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>()))
                  .Returns(
                    new List<Request>() { expectedRequest }
                    );
            mockContext
                .Setup(context =>
                    context.Requests)
                .Returns(mockDbSet.Object);

            IRequestService requestService = new RequestService(mockContext.Object);

            return requestService;
        }
    }
}
