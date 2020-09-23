using Store.Data.Models;
using System.Collections.Generic;

namespace StoreWS.Service
{
    public interface IClientService
    {
        List<Client> Get();
    }
}
