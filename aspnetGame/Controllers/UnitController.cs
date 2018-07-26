using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gameClassLibrary.Database;
using gameClassLibrary.Models.Units;
using gameClassLibrary.Models.Units.ConcretUnits;
using gameClassLibrary.Models.Resources;

namespace aspnetGame.Controllers
{
    public class UnitController : Controller
    {
        private GameDBContext db = new GameDBContext();

        // GET: Units
        public async Task<ActionResult> Index()
        {
            List<Unit> units = new List<Unit>();
            units.AddRange(await db.Workers.ToListAsync());
            units.AddRange(await db.Medics.ToListAsync());
            return View(units);
        }

        // GET: Units/Details/5
        //public async Task<ActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Unit unit = await db.Units.FindAsync(id);
        //    if (unit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(unit);
        //}

        // GET: Units/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.UnitTypes = new SelectList(new List<String> { "Worker", "Medic" });
            ViewBag.AvaibleResources = await db.Resources.ToListAsync();
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] Unit unit, List<Resource> resources)
        {
            if (ModelState.IsValid)
            {
                if (unit is Worker)
                {
                    (unit as Worker).CollectableResources = resources;
                    db.Workers.Add(unit as Worker);
                }
                else if (unit is Medic)
                {
                    db.Medics.Add(unit as Medic);
                }
                
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        [HttpGet]
        public async Task<JsonResult> getAvaibleResources()
        {
            return Json(await db.Resources.ToListAsync());
        }

        public UnitController() : base()
        {

        }

        //// GET: Units/Edit/5
        //public async Task<ActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Unit unit = await db.Units.FindAsync(id);
        //    if (unit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(unit);
        //}

        //// POST: Units/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id")] Unit unit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(unit).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(unit);
        //}

        //// GET: Units/Delete/5
        //public async Task<ActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Unit unit = await db.Units.FindAsync(id);
        //    if (unit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(unit);
        //}

        //// POST: Units/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(long id)
        //{
        //    Unit unit = await db.Units.FindAsync(id);
        //    db.Units.Remove(unit);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

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
