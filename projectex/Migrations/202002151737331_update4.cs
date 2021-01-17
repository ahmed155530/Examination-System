namespace projectex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ITIs", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.ITIs", "Intake_Id", "dbo.Intakes");
            DropForeignKey("dbo.Students", "ITI_Id", "dbo.ITIs");
            DropForeignKey("dbo.ITIs", "Track_Id", "dbo.Tracks");
            DropIndex("dbo.Students", new[] { "ITI_Id" });
            DropIndex("dbo.ITIs", new[] { "Branch_Id" });
            DropIndex("dbo.ITIs", new[] { "Intake_Id" });
            DropIndex("dbo.ITIs", new[] { "Track_Id" });
            AddColumn("dbo.Students", "Branch_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Intake_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Track_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "Branch_Id");
            CreateIndex("dbo.Students", "Intake_Id");
            CreateIndex("dbo.Students", "Track_Id");
            AddForeignKey("dbo.Students", "Branch_Id", "dbo.Branches", "Branch_Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Intake_Id", "dbo.Intakes", "Intake_Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Track_Id", "dbo.Tracks", "Track_Id", cascadeDelete: true);
            DropColumn("dbo.Students", "ITI_Id");
            DropTable("dbo.ITIs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ITIs",
                c => new
                    {
                        ITI_Id = c.Int(nullable: false, identity: true),
                        Branch_Id = c.Int(),
                        Intake_Id = c.Int(),
                        Track_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ITI_Id);
            
            AddColumn("dbo.Students", "ITI_Id", c => c.Int());
            DropForeignKey("dbo.Students", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.Students", "Intake_Id", "dbo.Intakes");
            DropForeignKey("dbo.Students", "Branch_Id", "dbo.Branches");
            DropIndex("dbo.Students", new[] { "Track_Id" });
            DropIndex("dbo.Students", new[] { "Intake_Id" });
            DropIndex("dbo.Students", new[] { "Branch_Id" });
            DropColumn("dbo.Students", "Track_Id");
            DropColumn("dbo.Students", "Intake_Id");
            DropColumn("dbo.Students", "Branch_Id");
            CreateIndex("dbo.ITIs", "Track_Id");
            CreateIndex("dbo.ITIs", "Intake_Id");
            CreateIndex("dbo.ITIs", "Branch_Id");
            CreateIndex("dbo.Students", "ITI_Id");
            AddForeignKey("dbo.ITIs", "Track_Id", "dbo.Tracks", "Track_Id");
            AddForeignKey("dbo.Students", "ITI_Id", "dbo.ITIs", "ITI_Id");
            AddForeignKey("dbo.ITIs", "Intake_Id", "dbo.Intakes", "Intake_Id");
            AddForeignKey("dbo.ITIs", "Branch_Id", "dbo.Branches", "Branch_Id");
        }
    }
}
