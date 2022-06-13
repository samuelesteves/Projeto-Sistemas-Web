using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gregory.Context;
using Gregory.Models;

namespace Gregory.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly Contexto _contexto = new Contexto();       
        public ActionResult Index()
        {
            return View(_contexto.Fornecedores.ToList());   
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FornecedorModel fornecedorModel)
        {
            if (ModelState.IsValid)
            {
                _contexto.Fornecedores.Add(fornecedorModel);
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedorModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorModel fornecedorModel = _contexto.Fornecedores.Find(id);
            if (fornecedorModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorModel);
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorModel fornecedorModel = _contexto.Fornecedores.Find(id);
            if(fornecedorModel == null)
            {
                HttpNotFound();
            }
            return View(fornecedorModel);
        }

        [HttpPost]
        public ActionResult Edit(FornecedorModel fornecedorModel)
        {
            if (ModelState.IsValid)
            {
                _contexto.Entry(fornecedorModel).State = EntityState.Modified;
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedorModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorModel fornecedorModel = _contexto.Fornecedores.Find(id);
            if (fornecedorModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorModel);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            FornecedorModel fornecedorModel = _contexto.Fornecedores.Find(id);
            _contexto.Fornecedores.Remove(fornecedorModel);
            _contexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}