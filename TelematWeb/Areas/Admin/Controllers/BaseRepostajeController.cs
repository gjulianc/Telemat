using DevExpress.Web.Mvc;
using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelematWeb.Areas.Admin.Models.FormsViewModel;
using Entities;

namespace TelematWeb.Areas.Admin.Controllers
{
    public class BaseRepostajeController : Controller
    {
        protected IBaseRepostajeRepository baseRepostajeRepository;

        public BaseRepostajeController(IBaseRepostajeRepository _baseRepostajeRepository)
        {
            baseRepostajeRepository = _baseRepostajeRepository;
        }

        // GET: Admin/BaseRepostaje
        public ActionResult Index()
        {
            return View(baseRepostajeRepository.GetAll().ToList());
        }

        // GET: Admin/BaseRepostaje/ExternalEditFormEdit
        public ActionResult ExternalEditFormEdit(int Id)
        {
            if (Id == -1)
            {
                BaseRepostajeViewModel NewEntity = new BaseRepostajeViewModel { Id = -1 };
                ViewData["Accion"] = "Nueva Estación Base";                
                return View(NewEntity);
            }
            else
            {
                ViewData["Accion"] = String.Format("Actualización de la Estación Base {0}", Id);
                var entity = baseRepostajeRepository.GetByKey(Id) as BaseRepostaje;
                BaseRepostajeViewModel EditEntity = new BaseRepostajeViewModel
                {
                    Baudios = entity.Baudios,
                    CAE = entity.CAE,
                    CodigoControl = entity.CodigoControl,
                    CodigoFlota = entity.CodigoFlota,
                    CodigoPostal = entity.CodigoPostal,
                    Delegacion = entity.Delegacion,
                    Descripcion = entity.Descripcion,
                    Direccion = entity.Direccion,
                    Latitud = entity.Latitud,
                    Id = entity.Id,
                    Longitud = entity.Longitud,
                    Nombre = entity.Nombre,
                    Poblacion = entity.Poblacion,
                    PuertoComunicacion = entity.PuertoComunicacion,
                    Scu = entity.Scu,
                    Telefono = entity.Telefono,
                    ZonaHoraria = entity.ZonaHoraria
                };
                return View(EditEntity);
            }

            
        }

        // POST: Admin/BaseRepostaje/ExternalEditFormEdit
        [HttpPost]
        public ActionResult ExternalEditFormEdit(BaseRepostajeViewModel item)
        {
            if (ModelState.IsValid)            
                try
                {
                    if (item.Id == -1)
                    {
                        var entity = mapEntity(item, new BaseRepostaje()) as BaseRepostaje;
                        baseRepostajeRepository.Add(entity);
                    }
                    else
                    {
                        var entity = baseRepostajeRepository.GetByKey(item.Id) as BaseRepostaje;
                        entity = mapEntity(item, entity);
                        baseRepostajeRepository.Save();
                    }

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            
            else
            {
                return View();
            }
            
        }

        // GET: Admin/BaseRepostaje/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/BaseRepostaje/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Codigo del GridView
        [ValidateInput(false)]
        public ActionResult GridViewBasesPartial()
        {
            var model = baseRepostajeRepository.GetAll().ToList();
            return PartialView("_GridViewBasesPartial", model);
        }


        //Carga Mapa
        [ValidateInput(false)]
        public ActionResult CargaMapa(MarcadorBasesViewModel item)
        {
            MarcadorBasesViewModel marker = new MarcadorBasesViewModel { Nombre = item.Nombre, Latitud = item.Latitud, Longitud = item.Longitud };
            
            return PartialView("_Mapa", marker);
        }

        //Mapeamos el ViewModel con la entidad para proceder a la insercion o modificacion de la entidad
        private Entities.BaseRepostaje mapEntity(BaseRepostajeViewModel vm, BaseRepostaje entityUpdated)
        {

            entityUpdated.Nombre = vm.Nombre;
            entityUpdated.Baudios = vm.Baudios;
            entityUpdated.CAE = vm.CAE;
            entityUpdated.Descripcion = vm.Descripcion;
            entityUpdated.CodigoControl = vm.CodigoControl;
            entityUpdated.CodigoFlota = vm.CodigoFlota;
            entityUpdated.CodigoPostal = vm.CodigoPostal;
            entityUpdated.Delegacion = vm.Delegacion;
            entityUpdated.Direccion = vm.Direccion;
            entityUpdated.Latitud = vm.Latitud;
            entityUpdated.Longitud = vm.Longitud;
            entityUpdated.Poblacion = vm.Poblacion;
            entityUpdated.PuertoComunicacion = vm.PuertoComunicacion;
            entityUpdated.Scu = vm.Scu;
            entityUpdated.Telefono = vm.Telefono;
            entityUpdated.ZonaHoraria = vm.ZonaHoraria;
            return entityUpdated;

        }

    }
}
