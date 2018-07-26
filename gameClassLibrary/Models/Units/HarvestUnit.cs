using gameClassLibrary.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace gameClassLibrary.Models.Units
{
    public abstract class HarvestUnit : Unit
    {
        public List<Resource> CollectableResources { get; set; }
        public Double ResourceByTime { get; set; }
    }
}
