using Store.Data.Models;
using Store.Data.Repository.Base;

namespace StoreWS.Repository
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(StoreContext context) : base(context)
        {

        }
    }
}