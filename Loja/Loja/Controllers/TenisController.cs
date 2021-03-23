using Loja.Data;
using Loja.Models;
using System.Web.Mvc;

namespace Loja.Controllers
{
    public class TenisController : Controller
    {
        public ActionResult Index()
        {
            var list = new TenisDB().Select();
            return View(list);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tenis tenis) {
            if (ModelState.IsValid) {
                new TenisDB().Insert(tenis);
                return RedirectToAction("Index");
            }
            return View(tenis);
        }

        public ActionResult Edit(int id) {
            var tenis = new TenisDB().SelectById(id);
            return View(tenis);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tenis tenis) {
            if (ModelState.IsValid) {
                new TenisDB().Update(tenis);
                return RedirectToAction("Index");
            }
            return View(tenis);
        }

        public ActionResult Details(int id) {
            var tenis = new TenisDB().SelectById(id);
            return View(tenis);
        }

        public ActionResult Delete(int id) {
            var tenis = new TenisDB().SelectById(id);
            return View(tenis);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id) {
            new TenisDB().Delete(id);
            return RedirectToAction("Index");
        }
    }
}