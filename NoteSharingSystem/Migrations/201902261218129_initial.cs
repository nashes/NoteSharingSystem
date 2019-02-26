namespace NoteSharingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deparmants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        presedent_Id = c.Int(),
                        university_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Identities", t => t.presedent_Id)
                .ForeignKey("dbo.Universities", t => t.university_Id)
                .Index(t => t.presedent_Id)
                .Index(t => t.university_Id);
            
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Capacity = c.Int(nullable: false),
                        term = c.Int(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        Deparmant_Id = c.Int(),
                        Instructer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deparmants", t => t.Deparmant_Id)
                .ForeignKey("dbo.Instructers", t => t.Instructer_Id)
                .Index(t => t.Deparmant_Id)
                .Index(t => t.Instructer_Id);
            
            CreateTable(
                "dbo.Instructers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        deparmant_Id = c.Int(),
                        Identity_Id = c.Int(),
                        university_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deparmants", t => t.deparmant_Id)
                .ForeignKey("dbo.Identities", t => t.Identity_Id)
                .ForeignKey("dbo.Universities", t => t.university_Id)
                .Index(t => t.deparmant_Id)
                .Index(t => t.Identity_Id)
                .Index(t => t.university_Id);
            
            CreateTable(
                "dbo.Identities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Birth = c.Int(nullable: false),
                        Province = c.String(),
                        ImageAd = c.String(),
                        Nation = c.String(),
                        Password = c.String(),
                        Authority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Lecture_Id = c.Int(),
                        Publisher_Id = c.Int(),
                        rate_Id = c.Int(),
                        Instructer_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lectures", t => t.Lecture_Id)
                .ForeignKey("dbo.Identities", t => t.Publisher_Id)
                .ForeignKey("dbo.Rates", t => t.rate_Id)
                .ForeignKey("dbo.Instructers", t => t.Instructer_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Lecture_Id)
                .Index(t => t.Publisher_Id)
                .Index(t => t.rate_Id)
                .Index(t => t.Instructer_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        numberOfRate = c.Int(nullable: false),
                        totalPoint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GNO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Registeration = c.Int(nullable: false),
                        Deparmant_Id = c.Int(),
                        Identity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deparmants", t => t.Deparmant_Id)
                .ForeignKey("dbo.Identities", t => t.Identity_Id)
                .Index(t => t.Deparmant_Id)
                .Index(t => t.Identity_Id);
            
            CreateTable(
                "dbo.StudentLectures",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Lecture_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Lecture_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lectures", t => t.Lecture_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Lecture_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deparmants", "university_Id", "dbo.Universities");
            DropForeignKey("dbo.Deparmants", "presedent_Id", "dbo.Identities");
            DropForeignKey("dbo.Notes", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentLectures", "Lecture_Id", "dbo.Lectures");
            DropForeignKey("dbo.StudentLectures", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "Identity_Id", "dbo.Identities");
            DropForeignKey("dbo.Students", "Deparmant_Id", "dbo.Deparmants");
            DropForeignKey("dbo.Instructers", "university_Id", "dbo.Universities");
            DropForeignKey("dbo.Notes", "Instructer_Id", "dbo.Instructers");
            DropForeignKey("dbo.Notes", "rate_Id", "dbo.Rates");
            DropForeignKey("dbo.Notes", "Publisher_Id", "dbo.Identities");
            DropForeignKey("dbo.Notes", "Lecture_Id", "dbo.Lectures");
            DropForeignKey("dbo.Lectures", "Instructer_Id", "dbo.Instructers");
            DropForeignKey("dbo.Instructers", "Identity_Id", "dbo.Identities");
            DropForeignKey("dbo.Instructers", "deparmant_Id", "dbo.Deparmants");
            DropForeignKey("dbo.Lectures", "Deparmant_Id", "dbo.Deparmants");
            DropIndex("dbo.StudentLectures", new[] { "Lecture_Id" });
            DropIndex("dbo.StudentLectures", new[] { "Student_Id" });
            DropIndex("dbo.Students", new[] { "Identity_Id" });
            DropIndex("dbo.Students", new[] { "Deparmant_Id" });
            DropIndex("dbo.Notes", new[] { "Student_Id" });
            DropIndex("dbo.Notes", new[] { "Instructer_Id" });
            DropIndex("dbo.Notes", new[] { "rate_Id" });
            DropIndex("dbo.Notes", new[] { "Publisher_Id" });
            DropIndex("dbo.Notes", new[] { "Lecture_Id" });
            DropIndex("dbo.Instructers", new[] { "university_Id" });
            DropIndex("dbo.Instructers", new[] { "Identity_Id" });
            DropIndex("dbo.Instructers", new[] { "deparmant_Id" });
            DropIndex("dbo.Lectures", new[] { "Instructer_Id" });
            DropIndex("dbo.Lectures", new[] { "Deparmant_Id" });
            DropIndex("dbo.Deparmants", new[] { "university_Id" });
            DropIndex("dbo.Deparmants", new[] { "presedent_Id" });
            DropTable("dbo.StudentLectures");
            DropTable("dbo.Students");
            DropTable("dbo.Universities");
            DropTable("dbo.Rates");
            DropTable("dbo.Notes");
            DropTable("dbo.Identities");
            DropTable("dbo.Instructers");
            DropTable("dbo.Lectures");
            DropTable("dbo.Deparmants");
        }
    }
}
