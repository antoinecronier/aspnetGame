using aspnetGame.Controllers.Extensions;
using gameClassLibrary.Database;
using gameClassLibrary.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace aspnetGame.Controllers.Base
{
    public class AdminControllerBase<T> : Controller where T : ModelBase , new()
    {
        protected GameDBContext dbContext = new GameDBContext();

        public virtual ActionResult Index()
        {
            List<T> items = dbContext.Set<T>().ToList();
            return View(items);
        }

        [HttpGet]
        public virtual async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireRequestValue(new String[] {})]
        public virtual async Task<ActionResult> Create([Bind(Include = "")]T item)
        {
            if (ModelState.IsValid)
            {
                dbContext.Set<T>().Add(item);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(item);
        }

        [HttpGet]
        public virtual async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T item = await dbContext.Set<T>().FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> DeleteConfirmed(int? id)
        {
            T item = await dbContext.Set<T>().FindAsync(id);
            if (item != null)
            {
                dbContext.Set<T>().Remove(item);
                await dbContext.SaveChangesAsync();
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T item = await dbContext.Set<T>().FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit([Bind(Include = "")] T item)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(item).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpGet]
        public virtual async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T item = await dbContext.Set<T>().FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
