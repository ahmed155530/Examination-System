namespace projectex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instructors", "Instructor_Salary", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instructors", "Instructor_Salary", c => c.Int(nullable: false));
        }
    }
}
