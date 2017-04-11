using DevExpress.Web.Mvc;
using Data.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        // GET: Admin/BaseRepostaje/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/BaseRepostaje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BaseRepostaje/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/BaseRepostaje/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/BaseRepostaje/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
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

        public ActionResult ListBoxPartial()
        {
            return PartialView("_ListBoxPartial");
        }


        //Codigo del GridView
        [ValidateInput(false)]
        public ActionResult GridViewBasesPartial()
        {
            var model = baseRepostajeRepository.GetAll().ToList();
            return PartialView("_GridViewBasesPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewBasesPartialAddNew(Entities.BaseRepostaje item)
        {
            var model = baseRepostajeRepository.GetAll().ToList();
            if (ModelState.IsValid)
            {
                try
                {
                    baseRepostajeRepository.Add(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Por favor, corrige todos los errores.";
            return PartialView("_GridViewBasesPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewBasesPartialUpdate(Entities.BaseRepostaje item)
        {
            var model = baseRepostajeRepository.GetAll().ToList();
            if (ModelState.IsValid)
            {
                try
                {
                    baseRepostajeRepository.Update(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Por favor, corrige todos los errores.";
            return PartialView("_GridViewBasesPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewBasesPartialDelete(System.Int32 Id)
        {
            var model = baseRepostajeRepository.GetAll();
            if (Id >= 0)
            {
                try
                {
                   baseRepostajeRepository.Delete( baseRepostajeRepository.GetByKey(Id) );
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewBasesPartial", model);
        }
    }
}
