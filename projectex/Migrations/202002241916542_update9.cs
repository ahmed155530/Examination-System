namespace projectex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MC_Question", "MCQ_Istrue", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MC_Question", "MCQ_Istrue", c => c.Int(nullable: false));
        }
    }
}
