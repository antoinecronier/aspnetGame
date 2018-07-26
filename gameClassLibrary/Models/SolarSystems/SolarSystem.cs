using gameClassLibrary.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace gameClassLibrary.Models.SolarSystems
{
    public class SolarSystem : ModelBase
    {
        [Display(Name = "Solarsystem name")]
        public String Name { get; set; }
        public List<Planet> Planets { get; set; }
    }
}
