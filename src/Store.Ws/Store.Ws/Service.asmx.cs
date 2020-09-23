using StoreWS.Service;
using System.Web.Mvc;
using System.Web.Services;

namespace Store.Ws
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        private IImportService _importService;
        
        public Service()
        {
            _importService = DependencyResolver.Current.GetService<IImportService>();
        }       

        [WebMethod]
        public void Example()
        {
            _importService.Example();
        }
    }
}
