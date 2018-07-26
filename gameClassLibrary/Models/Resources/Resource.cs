using gameClassLibrary.Models.Base;
using gameClassLibrary.Models.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace gameClassLibrary.Models.Resources
{
    public class Resource : ModelBase, Displayable
    {
        public String Name { get; set; }
        public Double Quantity { get; set; }
        public String ImageURL { get; set; }
    }
}
