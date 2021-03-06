﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tracker.Models;

namespace Tracker.DAL
{
    public class TrackerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TrackerContext>
    {
        protected override void Seed(TrackerContext context)
        {
            var students = new List<Student>
            {
                new Student{FirstName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{FirstName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{FirstName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{FirstName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2015-09-01")},
                new Student{FirstName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2015-09-01")},
                new Student{FirstName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2017-09-01")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var modules = new List<Module>
            {
                new Module{ModCode="MOD002643",ModName="Image Processing", Level = 6, Credits = 15},
                new Module{ModCode="MOD004428",ModName="Core Maths for Computing", Level = 4, Credits = 15}
            };

            modules.ForEach(m => context.Modules.Add(m));
            context.SaveChanges();

            var moduleInstances = new List<ModuleInstance>
            {
                new ModuleInstance{ModuleID=1,SEM=SEM.SEM1,EYear=EYEAR.Y2016_17},
                new ModuleInstance{ModuleID=1,SEM=SEM.SEM1,EYear=EYEAR.Y2017_18}
            };

            moduleInstances.ForEach(m => context.ModuleInstances.Add(m));
            context.SaveChanges();
            // thi is a test

            var enrolments = new List<Enrollment>
            {
                new Enrollment{ModuleInstanceID=1, StudentID=1},
                new Enrollment{ModuleInstanceID=1, StudentID=2},
                new Enrollment{ModuleInstanceID=1, StudentID=3},
                new Enrollment{ModuleInstanceID=2, StudentID=4},
                new Enrollment{ModuleInstanceID=2, StudentID=5},
                new Enrollment{ModuleInstanceID=2, StudentID=6},

            };
            enrolments.ForEach(e => context.Enrollments.Add(e));
            context.SaveChanges();
        }
    }
}