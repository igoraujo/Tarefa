using Store.Web.StoreWS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult import(HttpPostedFileBase file)
        {
            //var client = new ServiceSoapClient();
            //client.Example();

            return View();
        }        
    }
}