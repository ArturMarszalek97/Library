using System;
using System.Collections.Generic;
using ProjektNET.ViewModels.Zawodnik;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektNET.BazaDanych;
using ProjektNET.Models;

namespace ProjektNET.Controllers
{
    public class KsiazkiController : Controller
    {
        private DB db = new DB();
        public ActionResult Index()
        {
            List<KsiazkaVM> listaVM = new List<KsiazkaVM>();
            
            if (db.userDB.ToList() != null)
            {
                foreach (Ksiazka s in db.userDB.ToList())
                {
                    KsiazkaVM nowy = new KsiazkaVM(s);
                    listaVM.Add(nowy);
                }
            }
            IndexVM lista = new IndexVM();
            lista.userList = listaVM;
            lista.username = User.Identity.Name;
            return View(lista);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsVM user = new DetailsVM();
            user.user = new KsiazkaVM(db.userDB.Find(id));

            if (user == null)
            {
                return HttpNotFound();
            }
            user.username = User.Identity.Name;
            return View(user);
        }

        [Authorize]
        public ActionResult Create()
        {
            CreateVM vm = new CreateVM();
            vm.username = User.Identity.Name;
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookID,title,lastName,price")] Ksiazka user)
        {
            if (ModelState.IsValid)
            {
                db.userDB.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CreateVM vm = new CreateVM();
            vm.user = new KsiazkaVM(user);
            vm.username = User.Identity.Name;

            return View(vm);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditVM user = new EditVM ();
            user.user = new KsiazkaVM(db.userDB.Find(id));
            if (user == null)
            {
                return HttpNotFound();
            }
            user.username = User.Identity.Name;
            return View(user);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookID,title,lastName,price")] Ksiazka user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            EditVM vm = new EditVM();
            vm.user = new KsiazkaVM(user);
            vm.username = User.Identity.Name;
            return View(vm);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeleteVM user = new DeleteVM();
            user.user = new KsiazkaVM(db.userDB.Find(id));

            if (user == null)
            {
                return HttpNotFound();
            }
            user.username = User.Identity.Name;
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Ksiazka user = db.userDB.Find(id);
            db.userDB.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public List<Ksiazka> sklep
        {
            get
            {
                if(Session["sklep"] == null)
                {
                    var lista = new List<Ksiazka>();

                    Session["sklep"] = lista;
                }

                return Session["sklep"] as List<Ksiazka>;
            }
        }

        [Authorize]
        public ActionResult Buy(int id)
        {
            Ksiazka kup = new Ksiazka();
            kup = db.userDB.Find(id);

            sklep.Add(kup);
            return List();
        }

        public ActionResult List()
        {
            var lista = sklep;
            return View("Buy", lista);
        }

        public ActionResult Remove(int id)
        {
            var rzecz = sklep.Where(u => u.bookID == id).FirstOrDefault();
            sklep.Remove(rzecz);

            var lista = sklep;

            return View("Buy", lista);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
