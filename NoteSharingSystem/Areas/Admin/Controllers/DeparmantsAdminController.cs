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
    public class DeparmantsAdminController : Controller
    {
        private NoteSharingDb db = new NoteSharingDb();

        // GET: Admin/DeparmantsAdmin
        public async Task<ActionResult> Index()
        {
            return View(await db.Departmants.ToListAsync());
        }

        // GET: Admin/DeparmantsAdmin/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deparmant deparmant = await db.Departmants.FindAsync(id);
            if (deparmant == null)
            {
                return HttpNotFound();
            }
            return View(deparmant);
        }

        // GET: Admin/DeparmantsAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DeparmantsAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Deparmant deparmant)
        {
            if (ModelState.IsValid)
            {
                db.Departmants.Add(deparmant);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(deparmant);
        }

        // GET: Admin/DeparmantsAdmin/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deparmant deparmant = await db.Departmants.FindAsync(id);
            if (deparmant == null)
            {
                return HttpNotFound();
            }
            return View(deparmant);
        }

        // POST: Admin/DeparmantsAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Deparmant deparmant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deparmant).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(deparmant);
        }

        // GET: Admin/DeparmantsAdmin/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deparmant deparmant = await db.Departmants.FindAsync(id);
            if (deparmant == null)
            {
                return HttpNotFound();
            }
            return View(deparmant);
        }

        // POST: Admin/DeparmantsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Deparmant deparmant = await db.Departmants.FindAsync(id);
            db.Departmants.Remove(deparmant);
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
