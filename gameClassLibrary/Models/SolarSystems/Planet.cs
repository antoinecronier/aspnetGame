using gameClassLibrary.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace gameClassLibrary.Models.SolarSystems
{
    public class Planet : ModelBase
    {
        [Display(Name = "Planet name")]
        public String Name { get; set; }

        [Display(Name = "AvaiblePlace")]
        [Range(5,100, ErrorMessage = "Avaible Place range is between 5 - 100")]
        public int AvaiblePlace { get; set; }
        
        public String Image { get; set; }

        [Display(Name = "SolarSystem")]
        public SolarSystem SolarSystem { get; set; }
    }
}
