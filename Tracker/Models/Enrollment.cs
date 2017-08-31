using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tracker.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public Int32 EnrollmentID { get; set; }
        public Int32 ModuleInstanceID { get; set; }
        public Int32 StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual ModuleInstance ModuleInstance { get; set; }
        public virtual Student Student { get; set; }

    }
}