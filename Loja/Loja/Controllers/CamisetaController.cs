using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste.Data;
using Teste.Models;

namespace Teste.Controllers {
    public class CamisetaController : Controller {
        // GET: Camiseta
        public ActionResult Index() {
            var lst = new CamisetaDB().Select();
            return View(lst);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Camiseta camiseta) {
            if (ModelState.IsValid) {
                new CamisetaDB().Insert(camiseta);
                return RedirectToAction("Index");
            }
            return View(camiseta);
        }

        public ActionResult Edit(int id) {
            var camiseta = new CamisetaDB().SelectById(id);
            return View(camiseta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Camiseta camiseta) {
            if (ModelState.IsValid) {
                new CamisetaDB().Update(camiseta);
                return RedirectToAction("Index");
            }
            return View(camiseta);
        }

        public ActionResult Delete(int id) {
            var camiseta = new CamisetaDB().SelectById(id);
            return View(camiseta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id) {
            new CamisetaDB().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id) {
            var camiseta = new CamisetaDB().SelectById(id);
            return View(camiseta);
        }
    }
}