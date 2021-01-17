namespace projectex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instructors", "Login_User_ID", "dbo.Login_User");
            DropIndex("dbo.Instructors", new[] { "Login_User_ID" });
            DropColumn("dbo.Instructors", "login_id");
            DropColumn("dbo.Instructors", "Manager_Id");
            RenameColumn(table: "dbo.Instructors", name: "Login_User_ID", newName: "login_id");
            RenameColumn(table: "dbo.Instructors", name: "Instructor2_Instructor_Id", newName: "Manager_Id");
            RenameIndex(table: "dbo.Instructors", name: "IX_Instructor2_Instructor_Id", newName: "IX_Manager_Id");
            AlterColumn("dbo.Instructors", "Instructor_HireDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Instructors", "login_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Instructors", "login_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Instructors", "login_id");
            AddForeignKey("dbo.Instructors", "login_id", "dbo.Login_User", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructors", "login_id", "dbo.Login_User");
            DropIndex("dbo.Instructors", new[] { "login_id" });
            AlterColumn("dbo.Instructors", "login_id", c => c.Int());
            AlterColumn("dbo.Instructors", "login_id", c => c.Int());
            AlterColumn("dbo.Instructors", "Instructor_HireDate", c => c.DateTime(nullable: false));
            RenameIndex(table: "dbo.Instructors", name: "IX_Manager_Id", newName: "IX_Instructor2_Instructor_Id");
            RenameColumn(table: "dbo.Instructors", name: "Manager_Id", newName: "Instructor2_Instructor_Id");
            RenameColumn(table: "dbo.Instructors", name: "login_id", newName: "Login_User_ID");
            AddColumn("dbo.Instructors", "Manager_Id", c => c.Int());
            AddColumn("dbo.Instructors", "login_id", c => c.Int());
            CreateIndex("dbo.Instructors", "Login_User_ID");
            AddForeignKey("dbo.Instructors", "Login_User_ID", "dbo.Login_User", "ID");
        }
    }
}
