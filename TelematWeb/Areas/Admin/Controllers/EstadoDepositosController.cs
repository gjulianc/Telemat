using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelematWeb.Areas.Admin.Controllers
{
    public class EstadoDepositosController : Controller
    {
        // GET: Admin/EstadoDepositos
        public ActionResult Index()
        {
            return View();
        }
    }
}