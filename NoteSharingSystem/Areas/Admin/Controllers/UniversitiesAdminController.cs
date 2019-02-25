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
    public class UniversitiesAdminController : Controller
    {
        private NoteSharingDb db = new NoteSharingDb();

        // GET: Admin/UniversitiesAdmin
        public async Task<ActionResult> Index()
        {
            return View(await db.Universities.ToListAsync());
        }

        // GET: Admin/UniversitiesAdmin/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = await db.Universities.FindAsync(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // GET: Admin/UniversitiesAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/UniversitiesAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Year")] University university)
        {
            if (ModelState.IsValid)
            {
                db.Universities.Add(university);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(university);
        }

        // GET: Admin/UniversitiesAdmin/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = await db.Universities.FindAsync(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // POST: Admin/UniversitiesAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Year")] University university)
        {
            if (ModelState.IsValid)
            {
                db.Entry(university).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(university);
        }

        // GET: Admin/UniversitiesAdmin/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = await db.Universities.FindAsync(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // POST: Admin/UniversitiesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            University university = await db.Universities.FindAsync(id);
            db.Universities.Remove(university);
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
