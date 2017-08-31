using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tracker.Models
{
    

    public class Module
    {
        public Int32 ModuleID { get; set; }
        public String ModCode { get; set; }
        public String ModName { get; set; }
        public Int32 Level { get; set; }
        public Int32 Credits { get; set; }

        public virtual ICollection<ModuleInstance> Instances { get; set; }

    }
}