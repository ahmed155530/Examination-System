namespace projectex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student_Degree", "isenterd", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student_Degree", "isenterd");
        }
    }
}
