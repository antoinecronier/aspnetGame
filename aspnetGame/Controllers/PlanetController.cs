using aspnetGame.Controllers.Base;
using gameClassLibrary.Models.SolarSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetGame.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PlanetController : AdminControllerBase<Planet>
    {
    }
}