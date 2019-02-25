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
    public class InstructersAdminController : Controller
    {
        private NoteSharingDb db = new NoteSharingDb();

        // GET: Admin/InstructersAdmin
        public async Task<ActionResult> Index()
        {
            return View(await db.Instructers.ToListAsync());
        }

        // GET: Admin/InstructersAdmin/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructer instructer = await db.Instructers.FindAsync(id);
            if (instructer == null)
            {
                return HttpNotFound();
            }
            return View(instructer);
        }

        // GET: Admin/InstructersAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/InstructersAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] Instructer instructer)
        {
            if (ModelState.IsValid)
            {
                db.Instructers.Add(instructer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(instructer);
        }

        // GET: Admin/InstructersAdmin/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructer instructer = await db.Instructers.FindAsync(id);
            if (instructer == null)
            {
                return HttpNotFound();
            }
            return View(instructer);
        }

        // POST: Admin/InstructersAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Instructer instructer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(instructer);
        }

        // GET: Admin/InstructersAdmin/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructer instructer = await db.Instructers.FindAsync(id);
            if (instructer == null)
            {
                return HttpNotFound();
            }
            return View(instructer);
        }

        // POST: Admin/InstructersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Instructer instructer = await db.Instructers.FindAsync(id);
            db.Instructers.Remove(instructer);
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
