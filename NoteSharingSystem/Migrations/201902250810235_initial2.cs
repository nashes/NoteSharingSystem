namespace NoteSharingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        numberOfRate = c.Int(nullable: false),
                        totalPoint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Notes", "rate_Id", c => c.Int());
            CreateIndex("dbo.Notes", "rate_Id");
            AddForeignKey("dbo.Notes", "rate_Id", "dbo.Rates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "rate_Id", "dbo.Rates");
            DropIndex("dbo.Notes", new[] { "rate_Id" });
            DropColumn("dbo.Notes", "rate_Id");
            DropTable("dbo.Rates");
        }
    }
}
