using gameClassLibrary.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace gameClassLibrary.Models.SolarSystems
{
    public class Planet : ModelBase
    {
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Display(Name = "SolarSystem")]
        public SolarSystem SolarSystem { get; set; }
    }
}
