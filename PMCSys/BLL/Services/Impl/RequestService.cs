using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using BLL.DTO;
using DAL.Repositories.Interfaces;
using AutoMapper;
using DAL.UnitOfWork;
using CCL.Security;
using CCL.Security.Identity;
using System.Security.Cryptography;

namespace BLL.Services.Impl
{
    public class RequestService
        : IRequestService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public RequestService( 
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<RequestDTO> GetRequests(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Employee)
                && userType != typeof(Ministry))
            {
                throw new MethodAccessException();
            }
            var ID = user.UID;
            var requestEntities = 
                _database
            .Requests
                    .Find(z => z.getRequestCustomer().customer_id == ID, pageNumber, pageSize);
            var mapper = 
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Request, RequestDTO>()
                    ).CreateMapper();
            var requestsDto = 
                mapper
                    .Map<IEnumerable<Request>, List<RequestDTO>>(
                        requestEntities);
            return requestsDto;
        }

        public void AddRequests(RequestDTO request)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Admin)
                || userType != typeof(Ministry))
            {
                throw new MethodAccessException();
            }
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            validate(request);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RequestDTO, Request>()).CreateMapper();
            var requestEntity = mapper.Map<RequestDTO, Request>(request);
            _database.Requests.Create(requestEntity);
        }

        private void validate(RequestDTO request)
        {
            if (request.getRequestCustomer().customer_id < 0)
            {
                throw new ArgumentException("Request must have a valid customerID");
            }
        }
    }
}
