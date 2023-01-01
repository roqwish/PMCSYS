using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
    public interface IRequestService
    {
        IEnumerable<RequestDTO> GetRequests(int page);
    }
}
