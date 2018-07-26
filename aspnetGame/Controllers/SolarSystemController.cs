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
using gameClassLibrary.Models.SolarSystems;
using aspnetGame.Controllers.Base;
using aspnetGame.Controllers.Extensions;

namespace aspnetGame.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class SolarSystemController : AdminControllerBase<SolarSystem>
    {
        public override async Task<ActionResult> Create()
        {
            ViewBag.Planets = await this.dbContext.Planets.Where(x => x.SolarSystem == null).ToListAsync();
            ViewBag.FormAction = "CreateWithPlanets";
            ViewBag.FormController = "SolarSystem";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequireRequestValue(new String[] { "Planets" })]
        public async Task<ActionResult> CreateWithPlanets([Bind(Include = "")] SolarSystem item, string Planets)
        {
            foreach (string id in Planets.Split(','))
            {
                item.Planets.Add(dbContext.Planets.Find(long.Parse(id)));
            }
            dbContext.SolarSystems.Add(item);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
