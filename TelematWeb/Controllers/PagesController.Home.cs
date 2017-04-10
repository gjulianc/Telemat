using System.Web.Mvc;

namespace TelematWeb.Controllers
{
    public partial class PagesController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
    }
}