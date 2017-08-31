namespace Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        ModuleInstanceID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.ModuleInstance", t => t.ModuleInstanceID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.ModuleInstanceID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.ModuleInstance",
                c => new
                    {
                        ModuleInstanceID = c.Int(nullable: false, identity: true),
                        ModuleID = c.Int(nullable: false),
                        SEM = c.Int(nullable: false),
                        EYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleInstanceID)
                .ForeignKey("dbo.Module", t => t.ModuleID, cascadeDelete: true)
                .Index(t => t.ModuleID);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        ModuleID = c.Int(nullable: false, identity: true),
                        ModCode = c.String(),
                        ModName = c.String(),
                        Level = c.Int(nullable: false),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Enrollment", "ModuleInstanceID", "dbo.ModuleInstance");
            DropForeignKey("dbo.ModuleInstance", "ModuleID", "dbo.Module");
            DropIndex("dbo.ModuleInstance", new[] { "ModuleID" });
            DropIndex("dbo.Enrollment", new[] { "StudentID" });
            DropIndex("dbo.Enrollment", new[] { "ModuleInstanceID" });
            DropTable("dbo.Student");
            DropTable("dbo.Module");
            DropTable("dbo.ModuleInstance");
            DropTable("dbo.Enrollment");
        }
    }
}
