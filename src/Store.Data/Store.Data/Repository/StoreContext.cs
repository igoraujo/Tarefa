using Store.Data.Service.ChangeTrackerService;
using System;
using System.Linq;
using System.Threading;
using System.Web;

namespace Store.Data.Models
{
    public class StoreContext : StoreContextLog
    {
        public const string ContextName = "StoreDB";
        private readonly IChangeTrackerService _changeTrackerService;

        public StoreContext() : base(ContextName)
        {
            _changeTrackerService = new ChangeTrackerService();
        }
    }
}



