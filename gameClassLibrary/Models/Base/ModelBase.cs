using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace gameClassLibrary.Models.Base
{
    public abstract class ModelBase
    {
        private long? id;

        [Key]
        public long? Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
