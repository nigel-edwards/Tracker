using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tracker.Models
{
    public enum SEM
    {
        SEM1, SEM2
    }
    public enum EYEAR
    {
        Y2016_17, Y2017_18
    }
    public class ModuleInstance
    {
        public Int32 ModuleInstanceID { get; set; }
        public Int32 ModuleID { get; set; }
        public SEM SEM { get; set; }
        public EYEAR EYear { get; set; }
        public virtual Module Module { get; set; }
    }
}