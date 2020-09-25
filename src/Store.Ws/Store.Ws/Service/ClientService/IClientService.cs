using Store.Data.Models;
using System;
using System.Collections.Generic;

namespace StoreWS.Service
{
    public interface IClientService
    {
        List<Client> Get();
        Client Get(Guid id);
    }
}
