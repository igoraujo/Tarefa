using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            return View("Import");
        }

        // GET: Order
        public ActionResult Import(HttpPostedFileBase file)
        {
            //var client = new ServiceSoapClient();
            //client.Example();

            return View();
        }
    }
}