using Store.Web.StoreWS;
using System;
using System.IO;
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
            if (file == null || file.ContentLength == 0)
            {
                ViewBag.StatusClass = "alert alert-warning";
                ViewBag.StatusMessage = "O campo não pode estar vazio.";

                return View();
            }

            var filePath = Path.Combine(Server.MapPath("~/TempImportFiles"), Path.GetFileName(file.FileName));

            try
            {
                file.SaveAs(filePath);

                var client = new ServiceSoapClient();
                client.ImportFile(filePath);

                ViewBag.StatusClass = "alert alert-success";
                ViewBag.StatusMessage = "Arquivo importado com sucesso.";

            }
            catch (Exception e)
            {
                string message = InnerException(e).Message;

                ViewBag.StatusClass = "alert alert-danger";
                ViewBag.StatusMessage = $"Erro ao importar o arquivo. Erro: {message}";
            }

            return View();
        }

        private Exception InnerException(Exception e)
        {
            if (e.InnerException != null)
            {
                InnerException(e.InnerException);
            }

            return e;
        }
    }
}