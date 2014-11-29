using Microsoft.ServiceBus.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetrolPriceNotifier.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Messenger()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Messenger(string Message)
        {

            var conStr = "Endpoint=sb://pwongtesthub-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=yEc2RZ5Xl3zaDKzHVI/iL9EcJHR66G5ZiJMVCkz1Hcs=";
            var hubPath = "pwongtesthub";

            var hub = NotificationHubClient.CreateClientFromConnectionString(conStr, hubPath);
            var alert = "{\"aps\":{\"badge\":1,\"sound\":\"default.wav\",\"alert\":\""+ Message +"\"}}";

            var outcome =  hub.SendAppleNativeNotificationAsync(alert);

            return View();
        }

        public JsonResult GetData()
        {
            return Json(new { id = DateTime.Now.ToString(), content = "Blech" }, JsonRequestBehavior.AllowGet);
        }
    }
}
