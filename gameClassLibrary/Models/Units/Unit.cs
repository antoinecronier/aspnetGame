using gameClassLibrary.Models.Base;
using gameClassLibrary.Models.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace gameClassLibrary.Models.Units
{
    public abstract class Unit : ModelBase, Buildable, Displayable
    {
        public String Name { get; set; }
    }
}
