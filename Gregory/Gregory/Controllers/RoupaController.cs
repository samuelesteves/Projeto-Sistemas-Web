using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gregory.Context;
using Gregory.Models;
using System.Data.Entity;
using System.Net;

namespace Gregory.Controllers
{
    public class RoupaController : Controller
    {
        
        private readonly Contexto _contexto = new Contexto();

        public ActionResult Index()
        {
            var roupas = _contexto.Roupas.Include(a => a.Fornecedor);
            return View(roupas.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.FornecedorId = new SelectList(_contexto.Fornecedores, "Id", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoupaModel roupaModel)
        {
            if (ModelState.IsValid)
            {
                _contexto.Roupas.Add(roupaModel);
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorId = new SelectList(_contexto.Fornecedores, "Id", "Nome", roupaModel.FornecedorId);
            return View(roupaModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoupaModel roupaModel = _contexto.Roupas.Find(id);
            if (roupaModel == null)
            {
                return HttpNotFound();
            }
            return View(roupaModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoupaModel roupaModel = _contexto.Roupas.Find(id);
            if (roupaModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(_contexto.Fornecedores, "Id", "Nome", roupaModel.FornecedorId);
            return View(roupaModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Edit(RoupaModel roupaModel)
        {
            if (ModelState.IsValid)
            {
                _contexto.Entry(roupaModel).State = EntityState.Modified;
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorId = new SelectList(_contexto.Fornecedores, "Id", "Nome", roupaModel.FornecedorId);
            return View(roupaModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoupaModel roupaModel = _contexto.Roupas.Find(id);
            if (roupaModel == null)
            {
                return HttpNotFound();
            }
            return View(roupaModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoupaModel roupaModel = _contexto.Roupas.Find(id);
            _contexto.Roupas.Remove(roupaModel);
            _contexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}