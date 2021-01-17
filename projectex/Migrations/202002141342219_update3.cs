namespace projectex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "student_code", c => c.String(maxLength: 450));
            CreateIndex("dbo.Students", "student_code", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Students", new[] { "student_code" });
            DropColumn("dbo.Students", "student_code");
        }
    }
}
