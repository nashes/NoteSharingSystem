using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NoteSharingSystem.DAL;
using NoteSharingSystem.Models;

namespace NoteSharingSystem.Areas.Admin.Controllers
{
    public class IdentitiesAdminController : Controller
    {
        private NoteSharingDb db = new NoteSharingDb();

        // GET: Admin/IdentitiesAdmin
        public async Task<ActionResult> Index()
        {
            return View(await db.Identities.ToListAsync());
        }

        // GET: Admin/IdentitiesAdmin/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identity identity = await db.Identities.FindAsync(id);
            if (identity == null)
            {
                return HttpNotFound();
            }
            return View(identity);
        }

        // GET: Admin/IdentitiesAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/IdentitiesAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Surname,Birth,Province,ImageAd,Nation,Password,Authority")] Identity identity)
        {
            if (ModelState.IsValid)
            {
                db.Identities.Add(identity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(identity);
        }

        // GET: Admin/IdentitiesAdmin/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identity identity = await db.Identities.FindAsync(id);
            if (identity == null)
            {
                return HttpNotFound();
            }
            return View(identity);
        }

        // POST: Admin/IdentitiesAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Surname,Birth,Province,ImageAd,Nation,Password,Authority")] Identity identity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(identity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(identity);
        }

        // GET: Admin/IdentitiesAdmin/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identity identity = await db.Identities.FindAsync(id);
            if (identity == null)
            {
                return HttpNotFound();
            }
            return View(identity);
        }

        // POST: Admin/IdentitiesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Identity identity = await db.Identities.FindAsync(id);
            db.Identities.Remove(identity);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
