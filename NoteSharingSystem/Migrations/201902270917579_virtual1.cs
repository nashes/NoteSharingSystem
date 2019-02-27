namespace NoteSharingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class virtual1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instructers", "deparmant_Id", "dbo.Deparmants");
            DropForeignKey("dbo.Instructers", "Identity_Id", "dbo.Identities");
            DropForeignKey("dbo.Lectures", "Instructer_Id", "dbo.Instructers");
            DropForeignKey("dbo.Notes", "Instructer_Id", "dbo.Instructers");
            DropForeignKey("dbo.Instructers", "university_Id", "dbo.Universities");
            DropIndex("dbo.Lectures", new[] { "Instructer_Id" });
            DropIndex("dbo.Instructers", new[] { "deparmant_Id" });
            DropIndex("dbo.Instructers", new[] { "Identity_Id" });
            DropIndex("dbo.Instructers", new[] { "university_Id" });
            DropIndex("dbo.Notes", new[] { "Instructer_Id" });
            DropColumn("dbo.Lectures", "Instructer_Id");
            DropColumn("dbo.Notes", "Instructer_Id");
            DropTable("dbo.Instructers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Instructers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        deparmant_Id = c.Int(),
                        Identity_Id = c.Int(),
                        university_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Notes", "Instructer_Id", c => c.Int());
            AddColumn("dbo.Lectures", "Instructer_Id", c => c.Int());
            CreateIndex("dbo.Notes", "Instructer_Id");
            CreateIndex("dbo.Instructers", "university_Id");
            CreateIndex("dbo.Instructers", "Identity_Id");
            CreateIndex("dbo.Instructers", "deparmant_Id");
            CreateIndex("dbo.Lectures", "Instructer_Id");
            AddForeignKey("dbo.Instructers", "university_Id", "dbo.Universities", "Id");
            AddForeignKey("dbo.Notes", "Instructer_Id", "dbo.Instructers", "Id");
            AddForeignKey("dbo.Lectures", "Instructer_Id", "dbo.Instructers", "Id");
            AddForeignKey("dbo.Instructers", "Identity_Id", "dbo.Identities", "Id");
            AddForeignKey("dbo.Instructers", "deparmant_Id", "dbo.Deparmants", "Id");
        }
    }
}
