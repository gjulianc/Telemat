using Data;
using Data.EFRepository;
using Data.Interfaz;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TelematWeb.Areas.Admin.Models.FormsViewModel;

namespace TelematWeb.Areas.Admin.Controllers
{
    public class TransaccionesController : AdminBaseController
    {
        private ITransaccionRepository transaccionRepository;

        public TransaccionesController(ITransaccionRepository _transaccionRepository)
        {
            transaccionRepository = _transaccionRepository;
        }

        // GET: Admin/Transacciones
        public ActionResult Index()
        {
            var model = transaccionRepository.GetAll();
            return View(model.ToList());
        }

        [ValidateInput(false)]
        public ActionResult GridViewTransaccionesPartial()
        {
            var model = transaccionRepository.GetAll();
            return PartialView("_GridViewTransaccionesPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewTransaccionesPartialAddNew(Entities.Transaccion item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    transaccionRepository.Add(item);                    
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Por favor, corrige todos los errores.";
            return PartialView("_GridViewTransaccionesPartial" , transaccionRepository.GetAll().ToList());
        }
      

        [HttpPost]
        public ActionResult ApplyFilter(TransaccionFilterViewModel item)
        {
            //var model = repositorio.ObtenerTransacciones(item.Base, item.FechaHasta, item.FechaHasta, item.Vehiculo, item.RegistroDesde, item.RegistroHasta,
            //    item.UsuarioDesde, item.UsuarioHasta, item.Carburante, item.ModoUso, item.LitrosDesde, item.LitrosHasta);

            if (ModelState.IsValid)
            {
                
            }
            else
                ViewData["EditError"] = "Por favor, corrige todos los erroress.";
            return PartialView("_GridViewTransaccionesPartial", transaccionRepository.GetAll().ToList());
        }

       
    }
}